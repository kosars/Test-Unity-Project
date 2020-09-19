using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePalletes : MonoBehaviour 
{
    [Serializable]
    public class Pallete
    {
        public Color32[] colors = new Color32[4];
    }

    [SerializeField] public Pallete[] palletes;

    Color32[] currPallete;

    private void Awake()
    {
        currPallete = GetRandomPallete();
        SetStaticColors();
    }

    public Color32 GetPrimaryColor()
    {
        return currPallete[0];
    }

    public Color32 GetSecondaryColor()
    {
        return currPallete[1];
    } 

    private void SetStaticColors()
    {
        GameObject.Find("GroundPanel").GetComponent<MeshRenderer>().material.color = (currPallete[2]);
        GameObject.Find("SidePanel").GetComponent<MeshRenderer>().material.color = (currPallete[2]);
        GameObject.Find("SidePanel2").GetComponent<MeshRenderer>().material.color = (currPallete[2]);
        GameObject.Find("Main Camera").GetComponent<Camera>().backgroundColor = (currPallete[3]);
    }

    private Color32[] GetRandomPallete()
    {
        int index = UnityEngine.Random.Range(0, palletes.Length);
        return palletes[index].colors;
    }
}
