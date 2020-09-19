using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    float moveSpeed = 5f;

    Rigidbody m_Rigidbody;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        MoveCam();
    }
    void MoveCam()
    {
        float speedPerSec = moveSpeed * Time.deltaTime;
        m_Rigidbody.MovePosition(m_Rigidbody.position + (Vector3.forward * speedPerSec));
    }
}
