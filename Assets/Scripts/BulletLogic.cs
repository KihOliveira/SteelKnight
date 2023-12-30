using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    [SerializeField] private int speed;
    [SerializeField] private int damage;

    void Update()
    {
        transform.Translate(Vector3.right *speed * Time.deltaTime);
        if(transform.position.x >= 8.55){
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        //Instantiate(hitEffect, transform.position, Quaternion.identity);
        if(collision.gameObject.CompareTag("Enemy")){
            EnemyAttributes enemy = collision.gameObject.GetComponent<EnemyAttributes>();
            enemy.TakeDamage();
            //Debug.Log("Colidiu com inimigo, vida do inimigo:" + enemy.GetLife());
            Destroy(gameObject);
        }
        else if(collision.gameObject.CompareTag("EnemyProjectile")){
            EnemyBulletLogic enemyP = collision.gameObject.GetComponent<EnemyBulletLogic>();
            enemyP.TakeDamage();
            Destroy(gameObject);
        }
        else if(collision.gameObject.CompareTag("Door")){
            FindAnyObjectByType<DoorLogic>().TakeDamage();
            Destroy(gameObject);
        }
        
  }

}
