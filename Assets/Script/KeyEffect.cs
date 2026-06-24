using UnityEngine;

public class KeyEffect : MonoBehaviour
{
    public GameObject effectPrefab;
    private Vector3 rotationSpeed;

    void Start()
    {
        rotationSpeed = new Vector3(0.0f, Random.Range(0.0f, 0.5f), 0.0f );
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
