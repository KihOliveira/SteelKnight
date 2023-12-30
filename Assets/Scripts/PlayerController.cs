using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameInput gameInput;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firepoint1;
    [SerializeField] private Transform firepoint2;
    [SerializeField] private Transform firepoint3;
    [SerializeField] private bool canFire = true;
    [SerializeField] private PlayerAttributes attributes;
    [SerializeField] private  ShieldLogic shield;
    [SerializeField] private float maxX;
    [SerializeField] private float maxY;
    private bool canUseShield;
    private void Start() {
        attributes = gameObject.GetComponent<PlayerAttributes>();
        StartCoroutine(ShotReload());
    }

    public void Update(){
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        
        //movement
        Vector3 moveDir = new Vector3(inputVector.x , inputVector.y, 0);// (x, y, z)
        float moveSpeed = GetComponent<PlayerAttributes>().GetSpeed();
        transform.position += moveDir * Time.deltaTime * moveSpeed;
        
        if(transform.position.y >= maxY){
            transform.position = new Vector3(transform.position.x , maxY , 0);
        }if(transform.position.y <= -maxY){
            transform.position = new Vector3(transform.position.x , -maxY , 0);
        }if(transform.position.x >= maxX){
            transform.position = new Vector3(maxX , transform.position.y , 0);
        }if(transform.position.x <= -maxX){
            transform.position = new Vector3(-maxX , transform.position.y , 0);
        }

        canUseShield = FindObjectOfType<ShieldLogic>().GetComponent<ShieldLogic>().GetShieldUse();//Verifica se pode utilizar o escudo

        if (Input.GetButtonDown("Special") && canUseShield){
            shield.UseShield();
        }

        

        if (Input.GetKey("space") && canFire){
            Shoot();
        }
    }

    private IEnumerator ShotReload(){
        yield return new WaitForSeconds(0.3f);
        canFire = true;
        StartCoroutine(ShotReload());
    }

    private void Shoot(){
        if(attributes.GetUpgradeLevel() == 3){
            Instantiate(bulletPrefab, firepoint1.position, Quaternion.identity);
            Instantiate(bulletPrefab, firepoint2.position, firepoint2.rotation);
            Instantiate(bulletPrefab, firepoint3.position, firepoint3.rotation);
        }else if(attributes.GetUpgradeLevel() == 2){
            Instantiate(bulletPrefab, firepoint1.position, Quaternion.identity);
            Instantiate(bulletPrefab, firepoint2.position, firepoint2.rotation);
        }else{
            Instantiate(bulletPrefab, firepoint1.position, Quaternion.identity);
        }
        
        canFire = false;
    }
}
