using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    public float HP = 100;
    public Slider slider;

    // Start is called before the first frame update

    private void Dead()
    {
        Destroy(gameObject);
        
    }

    public float GetHp()
    {
        return HP;
    }

    public void ResetHP()
    {

    }

    public void Damage(float dmg)
    {
        HP = HP - dmg;
        slider.value = HP;
        if(HP <= 0)
        {
            Dead();
            Debug.Log("Enemy died!");
        }
    }

    

    
}
