using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Color32 color;
    public bool isSwitched = false;
    public AudioSource collisionAudio;

    MeshRenderer m_MeshRenderer;
    GamePalletes m_GamePalletes;
    ParticleSystemRenderer m_ParticleSystemRenderer;
    void Start()
    {
        m_MeshRenderer = GetComponent<MeshRenderer>();
        m_GamePalletes = GameObject.Find("Game").GetComponent<GamePalletes>();
        m_ParticleSystemRenderer = GetComponentInChildren<ParticleSystemRenderer>();
        SetPrimaryColor();

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<ColorObject>(out ColorObject component))
        {
            collisionAudio.Play();
            if (!component.color.Equals(this.color))
                GameObject.Find("Game").GetComponent<GameState>().Defeat();
        }
    }

    /// <summary>Swithces primary and seocndry colors of player.</summary>
    public void SwitchColor()
    {
        if (!isSwitched)
            SetSecondaryColor();
        else
            SetPrimaryColor();
    }

    private void SetPrimaryColor()
    {
        isSwitched = false;
        color = m_GamePalletes.GetPrimaryColor();
        m_MeshRenderer.material.color = color;
        m_MeshRenderer.material.SetColor("_EmissionColor", color);
        m_ParticleSystemRenderer.material = m_MeshRenderer.material;


    }

    private void SetSecondaryColor()
    {
        isSwitched = true;
        color = m_GamePalletes.GetSecondaryColor();
        m_MeshRenderer.material.color = color;
        m_MeshRenderer.material.SetColor("_EmissionColor", color);
        m_ParticleSystemRenderer.material = m_MeshRenderer.material;

    }
}
