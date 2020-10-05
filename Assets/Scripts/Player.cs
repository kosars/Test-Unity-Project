using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static event Action OnDefeat;

    public Color32 color;
    public bool isSwitched = false; //TODO:Make enum and state Machine

    [SerializeField] private AudioSource collisionAudio;
    [SerializeField] private MeshRenderer m_MeshRenderer;
    [SerializeField] private GamePalletes m_GamePalletes; //TODO: MAKE CHARACTER RENDERER SCRIPT
    [SerializeField] private ParticleSystemRenderer m_ParticleSystemRenderer;
    void Start() => SetPrimaryColor();//TODO: CHARACTER COLOR SCRIPT

    private void OnCollisionEnter(Collision collision) //TODO: CHARACTER COLLISION SCRIPT
    {
        if (collision.gameObject.TryGetComponent<ColorObject>(out ColorObject component))
        {
            collisionAudio.Play();
            if (!component.color.Equals(this.color))
            {
                GameObject.Find("Game").GetComponent<GameState>().Defeat();
                OnDefeat?.Invoke();
            }
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
