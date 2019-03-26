using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    public GameMaster gm;
    public GameObject startPoint;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("save");
            gm.savePointState.transform.position = transform.position;
        }
    }
}
