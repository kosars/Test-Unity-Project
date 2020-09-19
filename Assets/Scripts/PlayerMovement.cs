using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float moveSpeed = 5f;

    Rigidbody m_Rigidbody;
    Vector3 m_Movement;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();

    }

    void Update()
    {
        //for pc
        /*float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize();*/

    }
    private void FixedUpdate()
    {
        //for mobile
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved && touch.deltaPosition.magnitude > 10)
                m_Movement.Set(touch.deltaPosition.x ,0f,touch.deltaPosition.y);
            else if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Ended) 
                m_Movement.Set(0f,0f,0f);
            m_Movement.Normalize();
        }
        MovePlayer();
    }
    void MovePlayer()
    {
        m_Rigidbody.velocity = (Vector3.forward * moveSpeed) + (m_Movement *moveSpeed);
    }
}
