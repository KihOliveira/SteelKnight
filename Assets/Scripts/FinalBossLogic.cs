using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class FinalBossLogic : MonoBehaviour {
    [SerializeField] private GameObject[] shotPatterns;
    [SerializeField] private Transform firepoint1;
    [SerializeField] private Transform firepoint2;
    [SerializeField] private Transform firepoint3;
    [SerializeField] private float shotReload;
    [SerializeField] private int firepAmount;
    [SerializeField] private bool canFire;
    [SerializeField] private bool isOnScreen = false;
    private int speed = 4;
    private GameObject player;

    void Start() {
        player = FindObjectOfType<PlayerAttributes>().GameObject();
        StartCoroutine(CallBulletSpawn()); 
    }

    //Topo 4.13 | Baixo -4.33 | Meio 0
    void Update() {

        if(transform.position.x <= 9.1){
            isOnScreen = true;
        }
        
        if(transform.position.x > 6.7){
            transform.Translate(Vector3.left *speed * Time.deltaTime);
        }

        Vector3 playerPosition = player.transform.position;
        //0.5~1.5
        if(playerPosition.y >= 0.5f && playerPosition.y < 1.5f){
            if(transform.position.y <1.5){  
                transform.Translate(Vector3.up * speed * Time.deltaTime);
            }else if(transform.position.y > 1.5){
                transform.Translate(Vector3.down * speed * Time.deltaTime);
            }else if(transform.position.y == 1.5){
                transform.position = new Vector3(transform.position.x , 1.5f , 0);
            }
        }
        //1.6~3
        if(playerPosition.y >= 1.6f && playerPosition.y < 3f){
            if(transform.position.y < 2.9f){  
                transform.Translate(Vector3.up * speed * Time.deltaTime);
            }else if(transform.position.y > 2.9f){
                transform.Translate(Vector3.down * speed * Time.deltaTime);
            }else if(transform.position.y == 2.9f){
                transform.position = new Vector3(transform.position.x , 2.9f , 0);
            }
        }
        //-0.5~-1.5
        if(playerPosition.y <= -0.5f && playerPosition.y > -1.5f){
            if(transform.position.y <-1.5){  
                transform.Translate(Vector3.up * speed * Time.deltaTime);
            }else if(transform.position.y > -1.5){
                transform.Translate(Vector3.down * speed * Time.deltaTime);
            }else if(transform.position.y == -1.5){
                transform.position = new Vector3(transform.position.x , -1.5f , 0);
            }
        } 
        //-1.6~-3
        if(playerPosition.y <= -1.6f && playerPosition.y > -3f){
            if(transform.position.y < -2.9f){  
                transform.Translate(Vector3.up * speed * Time.deltaTime);
            }else if(transform.position.y > -2.9f){
                transform.Translate(Vector3.down * speed * Time.deltaTime);
            }else if(transform.position.y == -2.9f){
                transform.position = new Vector3(transform.position.x , -2.9f , 0);
            }
        }
    }

    IEnumerator CallBulletSpawn(){    //Ativa efeitos de passivas a cada 1 segundo
    if(isOnScreen){
        if(firepAmount == 3){
            Instantiate(shotPatterns[Random.Range(0,shotPatterns.Length)], firepoint1.position, Quaternion.identity);
            Instantiate(shotPatterns[Random.Range(0,shotPatterns.Length)], firepoint2.position, firepoint2.rotation);
            Instantiate(shotPatterns[Random.Range(0,shotPatterns.Length)], firepoint3.position, firepoint3.rotation);
        }else if(firepAmount == 2){
            Instantiate(shotPatterns[Random.Range(0,shotPatterns.Length)], firepoint1.position, Quaternion.identity);
            Instantiate(shotPatterns[Random.Range(0,shotPatterns.Length)], firepoint2.position, firepoint2.rotation);
        }else{
            Instantiate(shotPatterns[Random.Range(0,shotPatterns.Length)], firepoint1.position, Quaternion.identity);
        }
    }
    yield return new WaitForSeconds(shotReload);
    StartCoroutine(CallBulletSpawn());
    }
}
