using UnityEngine;

public class ItemEffect : MonoBehaviour
{
    public GameObject effectPrefab;
    private Vector3 rotationSpeed;

    void Start()
    {
        rotationSpeed = new Vector3(0.2f, 0.3f, 0.1f);
    }

    void Update()
    {
        transform.Rotate(rotationSpeed);
    }

    public void OnDeath()
    {
        if (effectPrefab != null)
        {
            Instantiate(effectPrefab, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
