using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCollider : MonoBehaviour
{
    public Animator doorAnimator; // Reference to the door animator
    public string doorOpenAnimationName = "isOpen_Obj_"; // Name of the animation to play
    public GameObject doorLeft; // Left part of the double door
    public GameObject doorRight; // Right part of the double door

    private bool isDoorOpen = false;

    // This method is called when another collider enters the trigger collider
    private void OnTriggerEnter(Collider other)
    {
        // Check if the player has entered the collider
        if (other.CompareTag("player") && !isDoorOpen)
        {
            OpenDoors();
            isDoorOpen = true;
        }
    }

    // This method opens the doors
    private void OpenDoors()
    {
        // Play the door opening animation using the Animator component
        if (doorAnimator != null)
        {
            doorAnimator.Play(doorOpenAnimationName);
        }

        // Additional logic to open the door (optional), such as moving or rotating the door parts
        // For example, you could move the door parts to simulate them opening

        StartCoroutine(OpenDoorSequence());
    }

    // Coroutine to handle the door opening sequence
    private IEnumerator OpenDoorSequence()
    {
        // Simulating door opening, e.g., moving both doors over time
        float duration = 2f;
        Vector3 leftDoorStartPos = doorLeft.transform.position;
        Vector3 rightDoorStartPos = doorRight.transform.position;

        Vector3 leftDoorEndPos = leftDoorStartPos + new Vector3(-2f, 0, 0); // Move left door left
        Vector3 rightDoorEndPos = rightDoorStartPos + new Vector3(2f, 0, 0); // Move right door right

        float elapsedTime = 0;
        while (elapsedTime < duration)
        {
            doorLeft.transform.position = Vector3.Lerp(leftDoorStartPos, leftDoorEndPos, elapsedTime / duration);
            doorRight.transform.position = Vector3.Lerp(rightDoorStartPos, rightDoorEndPos, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Make sure doors are at their final positions
        doorLeft.transform.position = leftDoorEndPos;
        doorRight.transform.position = rightDoorEndPos;
    }
}
