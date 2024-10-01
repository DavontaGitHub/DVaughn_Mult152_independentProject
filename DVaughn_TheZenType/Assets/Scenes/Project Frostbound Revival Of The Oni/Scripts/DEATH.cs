using UnityEngine;

public class DEATH : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        // Get the AudioSource component from the GameObject
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component is missing on the Water Hazard Detector GameObject!");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Check if the audio clip is assigned to the AudioSource
            if (audioSource != null && audioSource.clip != null)
            {
                // Play the assigned audio clip
                audioSource.Play();
            }
            else
            {
                Debug.LogError("Audio clip is not assigned to the AudioSource!");
            }
        }
    }
}



