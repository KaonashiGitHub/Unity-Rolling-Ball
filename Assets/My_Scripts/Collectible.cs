using UnityEngine;

public class Collectible : MonoBehaviour
{
    public float rotationSpeed = 3.0f;
    public GameObject onCollectEffect;

    private void FixedUpdate()
    {
        transform.Rotate(0, rotationSpeed, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);

            if (onCollectEffect != null)
            {
                Instantiate(onCollectEffect, transform.position, transform.rotation);
            }
        }
    }
}