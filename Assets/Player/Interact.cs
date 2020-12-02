using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    private Transform player;
    
    public float interactableRange = 4f;

    private DialogueManager dialogueManager;
    public float dialogueTriggerRadius = 4.0f;
    Collider conversationPartner;

    void Start()
    {
        player = GetComponent<Transform>();
        dialogueManager = FindObjectOfType<DialogueManager>();
        conversationPartner = null;
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] npcs_inRadius = Physics.OverlapSphere(player.position, dialogueTriggerRadius, LayerMask.GetMask("NPC"));
        //Collider[] interactableObjectsInRange = Physics.Raycast()
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //Collider[] lel = Physics.Raycast()

        if (Input.GetButtonDown("Interact"))
        {
            //Går videre i samtalen
            if(conversationPartner != null)
            {
                dialogueManager.DisplayNextSentance();
            }
            //Laster inn og henter samtalen
            else if(npcs_inRadius.Length > 0)
            {
                conversationPartner = npcs_inRadius[0];
                conversationPartner.GetComponent<NPCDialogue>().TriggerDialogue();
            }
        }

        if(conversationPartner != null && npcs_inRadius.Length == 0 )
        {
            conversationPartner = null;
            dialogueManager.EndDialogue();
        }
        
    }
}
