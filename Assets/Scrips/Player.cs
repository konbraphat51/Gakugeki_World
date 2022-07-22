using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 10f;

    private Rigidbody rigid;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        CheckInput();
    }

    private void CheckInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            GoFoward();
        }

        if (Input.GetKey(KeyCode.S))
        {
            GoBack();
        }

        if (Input.GetKeyUp(KeyCode.W)
            || Input.GetKeyUp(KeyCode.S))
        {
            Stop();
        }
    }

    private void GoFoward()
    {
        Quaternion rotation = transform.rotation;
        Vector3 speedVec = new Vector3(0, 0, speed);
        Vector3 vec = rotation * speedVec;
        rigid.velocity = new Vector3(vec.x, 0, vec.z);     //getting rid of y
    }

    private void Stop()
    {
        rigid.velocity = Vector3.zero;
    }

    private void GoBack()
    {
        Quaternion rotation = transform.rotation;
        Vector3 speedVec = new Vector3(0, 0, -speed);
        Vector3 vec = rotation * speedVec;
        rigid.velocity = new Vector3(vec.x, 0, vec.z);     //getting rid of y
    }
}
