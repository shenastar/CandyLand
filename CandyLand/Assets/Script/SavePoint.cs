using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    public GameMaster gm;
    private bool finish = false;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        finish = this.gameObject.name == "FinishState" ? true : false;
        if (collision.tag == "Player" && !finish)
        {
            Debug.Log("save");
            gm.savePointState.transform.position = transform.position;
        }
        if(collision.tag == "Player" && finish)
        {
            Debug.Log("finish");
            gm.stageClear();
        }
    }
}
