using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletLogic : MonoBehaviour
{
     [SerializeField] private int speed;
    [SerializeField] private int damage;
    [SerializeField] private bool up;
    [SerializeField] private bool isBossProjectileUp;
    [SerializeField] private bool down;
    [SerializeField] private int life;
    private SpriteRenderer sR;
    [SerializeField] private bool isProjectile;
    [SerializeField] private int scoreValue;
    [SerializeField] private bool isInvulnerable;

    private void Start() {
        sR = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {   
        
        if(up){
            transform.Translate(Vector3.up *speed *Time.deltaTime);
            transform.Translate(Vector3.left *speed/2 * Time.deltaTime);
        }
        else if(down){
            transform.Translate(Vector3.down *speed *Time.deltaTime);
            transform.Translate(Vector3.left *speed/2 * Time.deltaTime);
        }
        else if(isBossProjectileUp){
            transform.Translate(Vector3.up *speed *Time.deltaTime);
        }
        else{
            transform.Translate(Vector3.left *speed * Time.deltaTime);
        }
        
        
        if(transform.position.x <= -8.55){
            Destroy(gameObject);
        }else if(transform.position.x >= 8.9 && isProjectile){
            Destroy(gameObject);
        }else if(transform.position.y >= 6){
            Destroy(gameObject);
        }
    }

    public int getScore(){
        return this.scoreValue;
    }

   public void TakeDamage(){
        life -= 1;
        if(!isProjectile){
            Invulnerability();
        }
        if(life <= 0 ){
            FindObjectOfType<ScoreController>().addScore(getScore());
            Destroy(this.gameObject);
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
        if(collision.gameObject.CompareTag("Player")){
            PlayerAttributes player = collision.gameObject.GetComponent<PlayerAttributes>();
            player.TakeDamage();
            Destroy(gameObject);
        }
        else if(collision.gameObject.CompareTag("Shield")){
            Destroy(gameObject);
        }
        
  }
}
