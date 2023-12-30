using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLogic : MonoBehaviour
{
    private int life = 4;
    [SerializeField] private SpriteRenderer sR;
    [SerializeField] private BoxCollider2D collider;
    [SerializeField] private string nextLevel;
    private bool isInvulnerable;

    void Start()
    {
     sR.enabled = false; 
     collider.enabled = false;
    }

    public void LevelComplete(){
        StartCoroutine(WaitForSpawn());
    }

    IEnumerator WaitForSpawn(){
        yield return new WaitForSeconds(3f);
        sR.enabled = true; 
        collider.enabled = true;
    }

    public void TakeDamage(){
        life -= 1;
        Invulnerability();
        if(life <= 0 ){
            FindObjectOfType<GameManager>().LoadNextLevel(nextLevel);
            }
    }

    public void Invulnerability(){
        collider.enabled = false;
        isInvulnerable = true;
        StartCoroutine(InvulnerabilityCD());
        if(isInvulnerable){
            StartCoroutine(InvulnerabilityFlick());
        }
    }

    IEnumerator InvulnerabilityCD(){
        yield return new WaitForSeconds(1.5f);
        collider.enabled = true;
        isInvulnerable = false;
        sR.enabled = true;
    }

    IEnumerator InvulnerabilityFlick(){
        while(isInvulnerable){
            sR.enabled = true;
            yield return new WaitForSeconds(0.1f);
            sR.enabled = false;
            yield return new WaitForSeconds(0.1f);
            sR.enabled = true;
        }
    }

}
