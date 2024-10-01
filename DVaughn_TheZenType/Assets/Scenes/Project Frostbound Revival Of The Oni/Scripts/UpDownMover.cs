using UnityEngine;
using System.Collections; // Ensure this is included for IEnumerator

public class UpDownMover : MonoBehaviour
{
    public float height = 2.0f; // How far up and down to move
    public float speed = 1.0f; // Speed of the movement

    private Vector3 startingPosition;

    void Start()
    {
        // Store the initial position of the object
        startingPosition = transform.position;
        StartCoroutine(MoveUpDown());
    }

    private IEnumerator MoveUpDown()
    {
        while (true) // Infinite loop
        {
            // Move up
            float elapsedTime = 0f;
            Vector3 targetPosition = startingPosition + Vector3.up * height;

            while (elapsedTime < speed)
            {
                transform.position = Vector3.Lerp(startingPosition, targetPosition, (elapsedTime / speed));
                elapsedTime += Time.deltaTime;
                yield return null; // Wait for the next frame
            }

            transform.position = targetPosition; // Ensure we set it to the exact target position

            // Move down
            elapsedTime = 0f;
            targetPosition = startingPosition; // Return to starting position

            while (elapsedTime < speed)
            {
                transform.position = Vector3.Lerp(targetPosition + Vector3.up * height, targetPosition, (elapsedTime / speed));
                elapsedTime += Time.deltaTime;
                yield return null; // Wait for the next frame
            }

            transform.position = targetPosition; // Ensure we set it to the exact starting position
        }
    }
}

