using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorObject : MonoBehaviour
{
    public Color32 color;
    public bool isPrimary = true;
    MeshRenderer m_MeshRenderer;
    private void Start()
    {
        m_MeshRenderer = GetComponent<MeshRenderer>();
        if (isPrimary)
            SetPrimaryColor();
        else
            SetSecondaryColor();
    }

    public void SwitchColor()
    {
        if (isPrimary)
            SetSecondaryColor();
        else
            SetPrimaryColor();
    }

    private void SetPrimaryColor()
    {
        isPrimary = true;
        color = GameObject.Find("Game").GetComponent<GamePalletes>().GetPrimaryColor();
        m_MeshRenderer.material.color = color;
        m_MeshRenderer.material.SetColor("_EmissionColor", color);


    }

    private void SetSecondaryColor()
    {
        isPrimary = false;
        color = GameObject.Find("Game").GetComponent<GamePalletes>().GetSecondaryColor();
        m_MeshRenderer.material.color = color;
        m_MeshRenderer.material.SetColor("_EmissionColor", color);

    }
}