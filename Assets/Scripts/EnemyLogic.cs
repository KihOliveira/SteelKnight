using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab1;
    [SerializeField] private GameObject bulletPrefab2;
    [SerializeField] private GameObject bulletPrefab3;
    [SerializeField] private Transform firepoint1;
    [SerializeField] private Transform firepoint2;
    [SerializeField] private Transform firepoint3;
    [SerializeField] private int firepAmount;
    private bool isOnScreen = false;
    [SerializeField] private float shotReload;
    void Start()
    {
        StartCoroutine(CallBulletSpawn());  
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x <= 9.1){
            isOnScreen = true;
        }
    }

  IEnumerator CallBulletSpawn(){    //Ativa efeitos de passivas a cada 1 segundo
    if(isOnScreen){
        if(firepAmount == 3){
            Instantiate(bulletPrefab1, firepoint1.position, Quaternion.identity);
            Instantiate(bulletPrefab2, firepoint2.position, firepoint2.rotation);
            Instantiate(bulletPrefab3, firepoint3.position, firepoint3.rotation);
        }else if(firepAmount == 2){
            Instantiate(bulletPrefab1, firepoint1.position, Quaternion.identity);
            Instantiate(bulletPrefab2, firepoint2.position, firepoint2.rotation);
        }else{
            Instantiate(bulletPrefab1, firepoint1.position, Quaternion.identity);
        }
    }
    yield return new WaitForSeconds(shotReload);
    StartCoroutine(CallBulletSpawn());
    }
}
