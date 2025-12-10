using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    [SerializeField] private AudioClip pickupSound;
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player")) 
        {
            PlayerHealth healthScript = other.GetComponent<PlayerHealth>();

            if (healthScript != null)
            {

                healthScript.Heal(10); 
            }
            if (pickupSound != null)
        {

            AudioSource.PlayClipAtPoint(pickupSound, transform.position);
        }

            Destroy(gameObject); 
        }
    }
}