using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Player related variables
    public Transform spawnPoint;
    public GameObject player;
    private PlayerController playerController; // Use PlayerController instead of FirstPersonController

    // Game state variables
    private float elapsedTime = 0;
    private bool isRunning = false;
    private bool isFinished = false;

    // Artifact related variables
    public GameObject barrier;
    public int artifacts = 0;

    void Start()
    {
        // Enable character controllers to have their position set directly
        Physics.autoSyncTransforms = true;

        // Get the PlayerController from the player
        playerController = player.GetComponent<PlayerController>();

        // Disable controls at the start
        playerController.enabled = false;
    }

    void Update()
    {
        // Increment time if the game is running
        if (isRunning)
        {
            elapsedTime += Time.deltaTime;
        }

        // Check for barrier destruction
        if (artifacts >= 11)
        {
            Destroy(barrier);
        }
    }

    // Start the game
    private void StartGame()
    {
        elapsedTime = 0;
        isRunning = true;
        isFinished = false;

        // Position the player at the spawn point and enable controls
        PositionPlayer();
        playerController.enabled = true;
    }

    // Position the player at the spawn point
    public void PositionPlayer()
    {
        player.transform.position = spawnPoint.position;
        player.transform.rotation = spawnPoint.rotation;
    }

    // Runs when the player enters the finish zone
    public void FinishedGame()
    {
        isRunning = false;
        isFinished = true;
        playerController.enabled = false;
    }

    // Method to add artifacts
    public void AddArtifact()
    {
        artifacts++;
    }

    // Stop the timer (e.g., called when player dies)
    public void StopTimer()
    {
        isRunning = false;
    }

    // GUI for the game
    void OnGUI()
    {
        // Calculate minutes and seconds
        int minutes = (int)(elapsedTime / 60);
        int seconds = (int)(elapsedTime % 60);

        // Display the elapsed time in the top-left corner
        GUI.Box(new Rect(10, 10, 150, 40), "Elapsed Time:");
        GUI.Label(new Rect(10, 30, 150, 30), string.Format("{0:00}:{1:00}", minutes, seconds));

        if (!isRunning)
        {
            string message;

            if (isFinished)
            {
                message = "Click or Press Enter to Play Again";
            }
            else
            {
                message = "Click or Press Enter to Play";
            }

            // Define a new rectangle for the UI
            Rect startButton = new Rect(Screen.width / 2 - 120, Screen.height / 2, 240, 30);

            if (GUI.Button(startButton, message) || Input.GetKeyDown(KeyCode.Return))
            {
                StartGame();
            }
        }

        // If the player finished the game, show the final time
        if (isFinished)
        {
            GUI.Box(new Rect(Screen.width / 2 - 85, 185, 170, 60), "Your Time Was");
            GUI.Label(new Rect(Screen.width / 2 - 10, 200, 150, 30), string.Format("{0:00}:{1:00}", minutes, seconds));
        }
    }
}
