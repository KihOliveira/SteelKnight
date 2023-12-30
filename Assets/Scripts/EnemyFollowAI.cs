using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowAI : MonoBehaviour
{
    private Transform player;
    private Rigidbody2D rb;
    private Vector2 walkDirection;
    private EnemyAttributes attributes;
    private int damage;

    private void Awake() {
        attributes = this.GetComponent<EnemyAttributes>(); // procura os atributos
        rb = this.GetComponent<Rigidbody2D>(); //procura o componente (rigidbody) proprio
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update() {
        Vector3 direction = (player.position - transform.position).normalized;
        walkDirection = direction; 
    }

    private void FixedUpdate() {
        WalkTo(walkDirection);
    }

    private void WalkTo(Vector2 direction){
        if(direction.x < 0){
            gameObject.transform.localScale = new Vector3(-1,1,1); //Vira a sprite para a esquerda
        }   
        if(direction.x > 0){
            gameObject.transform.localScale = new Vector3(1,1,1);   //Vira a sprite para a direita
        }
        rb.MovePosition((Vector2)transform.position + (direction * 4 * Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Player")){
            PlayerAttributes player = collision.gameObject.GetComponent<PlayerAttributes>();
            player.TakeDamage();
            Debug.Log("Vida restante: " + player.GetHP());
        }
    }

}
