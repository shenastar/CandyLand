using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public GameObject player, savePointState;
    public GameObject[] heartPoint;
    public SavePoint sp;
    public bool isPlayerDead, isPlayerDrop;
    public int heart;
    private playerController controller;

    private void OnEnable()
    {
        controller =  player.GetComponent<playerController>();
    }

    private void Update()
    {
        isPlayerDrop = controller.isPlayerDrop;
        savePoint();
    }

    private void savePoint()
    {
        if (isPlayerDrop)
        {
            if (heart != 0)
            {

                player.transform.position = savePointState.transform.position;
                heart--;
                healthDecrease(heart);
                Debug.Log(heart);
            }
            else
            {
                isPlayerDead = true;
            }
        }
        if (isPlayerDead)
        {
            heart = 3;
            player.transform.position = sp.transform.position;
            for (int i = 0; i < heart; i++)
            {
                heartPoint[i].SetActive(true);
            }
            isPlayerDead = false;
        }
    }

    private void healthDecrease(int indexHeart)
    {
        heartPoint[indexHeart].SetActive(false);
    }
}
