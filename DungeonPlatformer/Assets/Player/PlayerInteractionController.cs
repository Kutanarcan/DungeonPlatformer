using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionController : MonoBehaviour
{
    IInteractable interactable;
    bool canInteract = true;
    KeyCode interactKey = KeyCode.Alpha4;

    void OnTriggerEnter2D(Collider2D other)
    {
        interactable = other.GetComponent<IInteractable>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (canInteract && interactable != null)
        {
            if (Input.GetKeyDown(interactKey))
            {
                canInteract = false;
                interactable.Interact();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        interactable = null;
        canInteract = true;
    }
}
