using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interact : MonoBehaviour
{
    private Transform player;
    public Transform holdingHand;
    public Slider powerSlider;

    
    public float interactableRange = 4f;
    Collider holdingObject;
    public float maxPower = 1f;
    private float currentPower;
    private bool throwing;

    private DialogueManager dialogueManager;
    public float dialogueTriggerRadius = 4.0f;
    Collider conversationPartner;

    void Start()
    {
        player = GetComponent<Transform>();
        dialogueManager = FindObjectOfType<DialogueManager>();
        conversationPartner = null;
        currentPower = 0f;
        throwing = false;
        powerSlider.value = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] npcs_inRadius = Physics.OverlapSphere(player.position, dialogueTriggerRadius, LayerMask.GetMask("NPC"));
        var cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.Log(cameraRay);
        RaycastHit[] inCrosshair = Physics.RaycastAll(Camera.main.ScreenPointToRay(Input.mousePosition), interactableRange, LayerMask.GetMask("Interactable"));

        //Oppdaterer posisjonen på det spilleren holder
        if(holdingObject != null)
        {
            EnableHoldingOnObject();
            if (throwing && Input.GetButtonUp("Interact"))
            {
                ThrowHoldingObject(cameraRay);
                throwing = false;
                currentPower = 0;
                powerSlider.value = currentPower;
                return;
            }
        }

        //Bygger kastearmen
        if (throwing)
        {
            if (currentPower > 100f) return;
            currentPower += 0.01f;
            powerSlider.value = currentPower;
            return;
        }
        

        //Klikker Interact
        if (Input.GetButtonDown("Interact"))
        {
            if(holdingObject != null)
            {
                throwing = true;
                return;
            }

            //Går videre i samtalen
            if(conversationPartner != null)
            {
                dialogueManager.DisplayNextSentance();
                return;
            }
            //Laster inn og henter samtalen
            else if(npcs_inRadius.Length > 0)
            {
                conversationPartner = npcs_inRadius[0];
                conversationPartner.GetComponent<NPCDialogue>().TriggerDialogue();
                return;
            }

            //Plukking
            if(inCrosshair.Length > 0)
            {
                if(holdingObject == null)
                {
                    holdingObject = inCrosshair[0].collider;
                    
                }
            }
        }

        if(conversationPartner != null && npcs_inRadius.Length == 0 )
        {
            conversationPartner = null;
            dialogueManager.EndDialogue();
        }
        
    }

    
    void EnableHoldingOnObject()
    {
        holdingObject.GetComponent<Transform>().position = holdingHand.position;
        holdingObject.GetComponent<Transform>().localScale = new Vector3(0.5f, 0.5f, 0.5f);
        holdingObject.GetComponent<BoxCollider>().enabled = false;
        
    }

    void ThrowHoldingObject(Ray cameraRay)
    {
        Collider temp = holdingObject;
        holdingObject = null;
        //temp.GetComponent<Transform>().localScale = new Vector3(1f, 1f, 1f);
        Vector3 mouseDirection = cameraRay.direction;
        temp.GetComponent<BoxCollider>().enabled = true;

        temp.attachedRigidbody.velocity = mouseDirection * currentPower * 10f;


    }
}
