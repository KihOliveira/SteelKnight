using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombLogic : MonoBehaviour
{
    private bool isCarried = true;
    [SerializeField] private int speed;

    // Update is called once per frame
    void Update()
    {
        if(!isCarried){
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Boss")){
            EnemyAttributes boss = collision.gameObject.GetComponent<EnemyAttributes>();
            boss.TakeDamage();
            Destroy(gameObject);
        }
        else if(collision.gameObject.CompareTag("Player")){
            PlayerAttributes player = collision.gameObject.GetComponent<PlayerAttributes>();
            player.TakeDamage();
            Destroy(gameObject);
        }
        else if(collision.gameObject.CompareTag("Enemy") && !isCarried){
            EnemyAttributes enemy = collision.gameObject.GetComponent<EnemyAttributes>();
            enemy.DestroyThis();
            Destroy(gameObject);
        }
    }

    public void Release(){
        isCarried = false;
    }
}
