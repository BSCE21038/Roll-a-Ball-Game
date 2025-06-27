using UnityEngine;

public class Pickup : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (audioSource != null)
            {
                audioSource.Play();  // Play sound
            }

            // Delay deactivating the object so the sound can finish
            StartCoroutine(DisableAfterSound());
        }
    }

    private System.Collections.IEnumerator DisableAfterSound()
    {
        // Wait for sound length or a short delay
        yield return new WaitForSeconds(audioSource.clip.length);
        gameObject.SetActive(false);
    }
}
