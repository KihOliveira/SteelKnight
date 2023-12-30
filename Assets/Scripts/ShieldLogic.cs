using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldLogic : MonoBehaviour
{
    [SerializeField] private CircleCollider2D collider;
    [SerializeField] private SpriteRenderer sR;
    private int shieldUses;
    private bool canUse = true;
    void Start()
    {
        shieldUses = 2;
        sR.enabled = false;
        collider.enabled = false;
        FindObjectOfType<ShieldCounter>().updateShieldCounter(shieldUses);
    }

    public void IncremetShieldUses(){
        shieldUses++;
        FindObjectOfType<ShieldCounter>().updateShieldCounter(shieldUses);
    }

    public void UseShield(){
        if(shieldUses>0){
            StartCoroutine(ShieldCD());
            shieldUses--;
            FindObjectOfType<ShieldCounter>().updateShieldCounter(shieldUses);
        }
    }

    IEnumerator ShieldCD(){
        canUse = false;
        sR.enabled = true;
        collider.enabled = true;
        yield return new WaitForSeconds(3f);
        sR.enabled = false;
        collider.enabled = false;
        canUse = true;
    }

    public bool GetShieldUse(){
        return canUse;
    }
}
