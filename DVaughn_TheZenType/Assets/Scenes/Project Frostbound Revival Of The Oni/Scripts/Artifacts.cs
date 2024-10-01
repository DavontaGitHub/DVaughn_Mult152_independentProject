using System.Collections.Generic;
using UnityEngine;

public class Artifacts : MonoBehaviour
{
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        // Find the GameManager object and get its component
        GameObject gameManagerObject = GameObject.Find("Game Manager");
        if (gameManagerObject != null)
        {
            gameManager = gameManagerObject.GetComponent<GameManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // No update logic needed for artifact
    }

    // Triggered when another collider enters this object's collider
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Call AddArtifact method in GameManager
            if (gameManager != null) // Ensure gameManager is set
            {
                gameManager.AddArtifact();
            }

            // Destroy the artifact after it is collected
            Destroy(gameObject);
        }
    }
}
