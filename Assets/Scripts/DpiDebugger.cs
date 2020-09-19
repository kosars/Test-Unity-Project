using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DpiDebugger : MonoBehaviour
{
    Text text;

    void Start()
    {
        text = GetComponent<Text>();
    }
    private void FixedUpdate()
    {

        
        //for mobile
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            string deltaPos = touch.deltaPosition.magnitude.ToString();
            if (touch.phase == TouchPhase.Moved) text.text = deltaPos + "  Moved";
            else if (touch.phase == TouchPhase.Began) text.text = deltaPos + "  Began";
            else if (touch.phase == TouchPhase.Stationary) text.text = deltaPos + "  Stationary";
            else if (touch.phase == TouchPhase.Ended) text.text = deltaPos + "  Ended";
            else text.text = deltaPos;


        }
    }
}
