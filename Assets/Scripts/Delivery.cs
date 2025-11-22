using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage;
    [SerializeField] float delay = 0.1f;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Package") && !hasPackage)
        {
            Debug.Log("Pickup package");
            hasPackage = true;
            GetComponent<ParticleSystem>().Play();
            Destroy(other.gameObject, delay);
        }
        
        if (other.CompareTag("Receiver") && hasPackage)
        {
            Debug.Log("Package delivered");
            hasPackage = false;
            Destroy(other.gameObject, delay);
            GetComponent<ParticleSystem>().Stop();
        }
        
    }
}
