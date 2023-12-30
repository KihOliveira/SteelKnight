using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float bulletSpeed = 5f; //Velocidade do projetil
    private int damage;
    private PlayerAttributes player;
    //private GameObject hitEffect;

  private void Awake() {
    rb = GetComponent<Rigidbody2D>();
    Vector3 trajectory = transform.position;
    rb.velocity =  new Vector2(trajectory.x, trajectory.y).normalized * bulletSpeed; //Faz com que a velocidade do projetil seja a mesma independente da distancia do mouse

    player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttributes>(); //Procura os atributos do jogador
  }

  private void Update() {
  }

  public float GetBulletSpeed(){
    return this.bulletSpeed;
  }

  public void SetBulletSpeed(float bulletSpeed){
    this.bulletSpeed = bulletSpeed;
  }

  private void OnCollisionEnter2D(Collision2D collision) {
    //Instantiate(hitEffect, transform.position, Quaternion.identity);
    
    if(collision.gameObject.CompareTag("Enemy")){
      EnemyAttributes enemy = collision.gameObject.GetComponent<EnemyAttributes>();
      enemy.TakeDamage();
      //Debug.Log("Colidiu com inimigo, vida do inimigo:" + enemy.GetLife());
      Destroy(gameObject);
    }
    else if(collision.gameObject.CompareTag("Wall")){
      //Debug.Log("Colidiu com uma parede");
      Destroy(gameObject);
    }

    
  }

}
