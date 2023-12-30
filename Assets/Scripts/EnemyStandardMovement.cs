using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStandardMovement : MonoBehaviour
{
    [SerializeField] private int speed;
    [SerializeField] private bool isBoss;
    [SerializeField] private bool upMovement;
    private GameManager gm;

    private void Start() {
        gm = FindObjectOfType<GameManager>();
    }
    void Update()
    {
        if(upMovement){
            transform.Translate(Vector3.up * speed * Time.deltaTime);

            if(isBoss){
                if(transform.position.y >= -1.83){
                    transform.position = new Vector3(transform.position.x, -1.83f, 0);
                }
            }
        }
        else{
            transform.Translate(Vector3.left *speed * Time.deltaTime);
        
            if(transform.position.x <= -10){
                gm.ReduceEnemyAmount();
                Destroy(gameObject);
            }

            if(isBoss){
                if(transform.position.x <= 6.7){
                    transform.position = new Vector3(6.7f , transform.position.y , 0);
                }
            }
        }
        
    }

}
