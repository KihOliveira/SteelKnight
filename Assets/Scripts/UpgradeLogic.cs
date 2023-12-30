using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeLogic : MonoBehaviour
{
    [SerializeField] private PlayerAttributes player;
    [SerializeField] private bool isEnergy;
    [SerializeField] private bool isHealth;
    [SerializeField] private bool isMoving;
    [SerializeField] private int speed;
    private ShieldLogic shield;

    void Start()
    {
        player = FindObjectOfType<PlayerAttributes>();
        shield = FindObjectOfType<ShieldLogic>();
    }

    void Update()
    {
        if(isMoving){
            transform.Translate(Vector3.left *speed * Time.deltaTime);
        }

        if(transform.position.x <= -8.55){
            Destroy(gameObject);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Player")){
            if(isEnergy){
                if(player.GetUpgradeLevel() == 3){
                    shield.IncremetShieldUses();
                }
                player.IncUpgradeLevel();
            }else if(isHealth){
                player.HealDamage();
            }
            Destroy(gameObject);
        }
    }
}
