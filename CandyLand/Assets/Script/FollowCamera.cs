using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public GameObject targetObject;
    public Vector3 targetPos;
    public float speed;

    private void Update()
    {
        targetPos = new Vector3(targetObject.transform.position.x, targetObject.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPos, speed * Time.deltaTime);
    }
}
