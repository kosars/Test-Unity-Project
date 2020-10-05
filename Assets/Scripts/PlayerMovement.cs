using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;

    [SerializeField] private Rigidbody _rigidbody;

    private Vector3 _movement;

    private void FixedUpdate()
    {
        //TODO: INPUT SCRIPT
        #if UNITY_STANDALONE
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        _movement.Set(horizontal, 0f, vertical);
        _movement.Normalize();
        #endif

        #if UNITY_ANDROID
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
        #endif
        MovePlayer();
    }
    void MovePlayer() => _rigidbody.velocity = (Vector3.forward + _movement ) *_moveSpeed;
}
