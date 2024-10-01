using UnityEngine;
using System.Collections; // Ensure this is included for IEnumerator

public class MoverLeftRight : MonoBehaviour
{
    public float distance = 2.0f; // How far left and right to move
    public float speed = 1.0f; // Speed of the movement

    private Vector3 startingPosition;

    void Start()
    {
        // Store the initial position of the object
        startingPosition = transform.position;
        StartCoroutine(MoveLeftRight());
    }

    private IEnumerator MoveLeftRight()
    {
        while (true) // Infinite loop
        {
            // Move right
            float elapsedTime = 0f;
            Vector3 targetPosition = startingPosition + Vector3.right * distance;

            while (elapsedTime < speed)
            {
                transform.position = Vector3.Lerp(startingPosition, targetPosition, (elapsedTime / speed));
                elapsedTime += Time.deltaTime;
                yield return null; // Wait for the next frame
            }

            transform.position = targetPosition; // Ensure we set it to the exact target position

            // Move left
            elapsedTime = 0f;
            targetPosition = startingPosition; // Return to starting position

            while (elapsedTime < speed)
            {
                transform.position = Vector3.Lerp(targetPosition + Vector3.right * distance, targetPosition, (elapsedTime / speed));
                elapsedTime += Time.deltaTime;
                yield return null; // Wait for the next frame
            }

            transform.position = targetPosition; // Ensure we set it to the exact starting position
        }
    }
}
