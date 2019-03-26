using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    public GameObject player, savePointState;
    public GameObject[] heartPoint;
    public SavePoint sp;
    public bool isPlayerDead, isPlayerDrop;
    public int heart;
    private playerController controller;
    private string nameScene;

    private void OnEnable()
    {
        nameScene = SceneManager.GetActiveScene().name;
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
            }
            else
            {
                isPlayerDead = true;
            }
        }
        if (isPlayerDead)
        {
            //StartCoroutine(splash());
            //heart = 3;
            //player.transform.position = sp.transform.position;
            //for (int i = 0; i < heart; i++)
            //{
            //    heartPoint[i].SetActive(true);
            //}
            //isPlayerDead = false;
            SceneManager.LoadScene(nameScene);
        }
    }

    private void healthDecrease(int indexHeart)
    {
        heartPoint[indexHeart].SetActive(false);
    }
    IEnumerator splash()
    {
        yield return new WaitForSeconds(5);
    }
}
