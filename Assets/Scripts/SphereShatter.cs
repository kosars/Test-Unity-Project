using UnityEngine;

public class SphereShatter : MonoBehaviour
{
    [SerializeField] private GameObject _shatteredPrefab;
    private void OnEnable() => Player.OnDefeat += HandleDefeat;
    private void OnDisable() => Player.OnDefeat -= HandleDefeat;

    private void HandleDefeat()
    {
        GameObject sphere = Instantiate(_shatteredPrefab, transform.position, transform.rotation);
        //TODO PropertiesInjection
        Rigidbody[] rigidbodies = sphere.GetComponentsInChildren<Rigidbody>();
        MeshRenderer[] meshRenderers = sphere.GetComponentsInChildren<MeshRenderer>();
        Color32 color = GetComponent<Player>().color;
        foreach(Rigidbody rb in rigidbodies) rb.AddExplosionForce(10f, transform.position, 2f);
        foreach (MeshRenderer mr in meshRenderers)
        {
            //TODO^ CHANGE THE PROPERTY NOT THE ALL MATERIAL
            mr.material.color = color;
            mr.material.SetColor("_EmissionColor", color);
        }
        Destroy(gameObject);
    }

}
