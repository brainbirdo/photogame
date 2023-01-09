using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using StarterAssets;

public class TalkToNPC : MonoBehaviour
{
    public Flowchart flowchart;
    public Interactable currentInteractable;
    public FirstPersonController fpsController;
    public PhotoCapture photoCap;
    public bool inDialogue = false;

    // Update is called once per frame
    void Update()
    {
        if (!inDialogue)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Execute Block");
                flowchart.ExecuteBlock(currentInteractable.blockName);
                inDialogue = true;
            }
        }

        if (inDialogue)
        {
            fpsController.CanMove = false;
            photoCap.canPhoto = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        Interactable interactable = collision.GetComponent<Interactable>();
        if (interactable)
        {
            currentInteractable = interactable;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        currentInteractable = null;
    }
    public void ExitBlock()
    {
        inDialogue = false;
        fpsController.CanMove = true;
        photoCap.canPhoto = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; 
    }
}
