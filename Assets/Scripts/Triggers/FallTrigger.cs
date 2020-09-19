using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name != "Player")
            Destroy(other.gameObject);
        else
            GameObject.Find("Game").GetComponent<GameState>().Defeat();
    }
}
