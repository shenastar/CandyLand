using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public GameObject player, savePointState;
    public bool isPlayerDead, isPlayerDrop;
    
    private void Update()
    {
        isPlayerDrop = player.gameObject.GetComponent<playerController>().isPlayerDrop;
        savePoint();
    }
    private void savePoint()
    {
        if (isPlayerDrop)
        {
            player.transform.position = savePointState.transform.position;
        }
        if (isPlayerDead)
        {
            //player.game
        }
    }
}
