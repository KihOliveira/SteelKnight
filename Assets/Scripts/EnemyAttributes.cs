using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttributes: MonoBehaviour
{

    [SerializeField] private int life;
    [SerializeField] private int scoreValue;
    private SpriteRenderer sR;
    [SerializeField] private bool isInvulnerable;
    [SerializeField] public bool isBossPart;
    [SerializeField] private BossLogic bosslogic;
    [SerializeField] private BombLogic bomb;
    [SerializeField] private bool isCarrier;
    private GameManager gm;

    private void Start() {
        sR = gameObject.GetComponent<SpriteRenderer>();
        gm = FindObjectOfType<GameManager>();
    }

    public void SetLife(int life){
        this.life = life;
    }

    public int GetLife(){
        return this.life;
    }

    public int getScore(){
        return this.scoreValue;
    }

    public void DestroyThis(){
        FindObjectOfType<ScoreController>().addScore(getScore());
        if(isBossPart){
            bosslogic.ReducePartsNumber();
            Destroy(gameObject);
        }else{
            if(isCarrier){
                bomb.Release();
            }
            gm.ReduceEnemyAmount();
            Destroy(gameObject);
        }
    }

    public void TakeDamage(){
        life -= 1;
        Invulnerability();
        if(life <= 0 ){
            DestroyThis();
        }
    }

    public void Invulnerability(){
        isInvulnerable = true;
        StartCoroutine(InvulnerabilityCD());
        if(isInvulnerable){
            StartCoroutine(InvulnerabilityFlick());
        }
    }

    IEnumerator InvulnerabilityCD(){
        yield return new WaitForSeconds(1.5f);
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

    private void OnCollisionEnter2D(Collision2D collision) {
        //Instantiate(hitEffect, transform.position, Quaternion.identity);
        if(collision.gameObject.CompareTag("Player") && !isBossPart){
            PlayerAttributes player = collision.gameObject.GetComponent<PlayerAttributes>();
            player.TakeDamage();
            DestroyThis();
        }
        else if(collision.gameObject.CompareTag("Shield") && !isBossPart){
            DestroyThis();
        }
  }

}
