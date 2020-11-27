using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandLogic : MonoBehaviour
{
    //Refs
    private Animator handAnimator;
    [SerializeField] private BoxCollider axeHitbox;

    
    void Start()
    {
        handAnimator = GetComponent<Animator>();
        axeHitbox.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    //Blir kalt når slaget skal være 
    void LightAttackHitboxEnable()
    {
        axeHitbox.enabled = true;
    }

    //Blir kalt når slaget er ferdig
    void LightAttackHitBoxDisabled()
    {
        axeHitbox.enabled = false;
    }

    //Blir kalt når animasjonen er ferdig, og man kan gjøre nye moves
    public void LightAttackAnimationEnd()
    {
        handAnimator.SetBool("lightAttack", false);
        handAnimator.SetBool("isAttacking", false);
    }
}
