using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandLogic : MonoBehaviour
{
    //Refs
    private Animator handAnimator;
    [SerializeField] BoxCollider axeHitBox;
    bool detectLightAttacks;

    List<Collider> damagedEnemies;
    
    void Start()
    {
        damagedEnemies = new List<Collider>();
        handAnimator = GetComponent<Animator>();
        detectLightAttacks = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (detectLightAttacks)
        {
            Collider[] colls = Physics.OverlapBox(axeHitBox.bounds.center, axeHitBox.bounds.extents, axeHitBox.transform.rotation);
            foreach (var c in colls)
            {
                if (c.tag == "Enemy" && !damagedEnemies.Contains(c))
                {
                    damagedEnemies.Add(c);
                    var enemyScript = c.GetComponent<EnemyScript>();
                    enemyScript.Damage(20);
                    Debug.Log("Hit " + c.name + "dealing 20 damage. Remaining: " + enemyScript.GetHp());
                }
            }
        }
    }



    //Blir kalt når slaget skal være 
    void LightAttackHitboxEnable()
    {
        detectLightAttacks = true;
        
    }

    //Blir kalt når slaget er ferdig
    void LightAttackHitBoxDisabled()
    {
        detectLightAttacks = false;
        damagedEnemies.Clear();
    }

    //Blir kalt når animasjonen er ferdig, og man kan gjøre nye moves
    public void LightAttackAnimationEnd()
    {
        handAnimator.SetBool("lightAttack", false);
        handAnimator.SetBool("isAttacking", false);
    }
}
