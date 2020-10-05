using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f; //TODO MAKE FROM SETTINGS

    [SerializeField] private Rigidbody m_Rigidbody;

    private void OnEnable() => Player.OnDefeat += HandleDefeat;
    private void OnDisable() => Player.OnDefeat -= HandleDefeat;

    private void HandleDefeat() => this.enabled = false;

    private void FixedUpdate() => MoveCam();
    void MoveCam()
    {
        float speedPerSec = moveSpeed * Time.deltaTime;
        m_Rigidbody.MovePosition(m_Rigidbody.position + (Vector3.forward * speedPerSec));
    }
}
