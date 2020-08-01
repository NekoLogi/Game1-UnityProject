using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueTrigger : Interactable
{
    public Dialogue dialogue;
    public UnityEvent eventAction;

    void Update()
    {
        if (Input.GetKeyDown("f")) {
            eventAction.Invoke();
        }
    }
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
