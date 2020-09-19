using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSwithcerTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            other.gameObject.GetComponent<Player>().SwitchColor();
        }
        else if (other.gameObject.layer.Equals("ColorObject"))
        {
            other.gameObject.GetComponent<ColorObject>().SwitchColor();

        }
    }
}
