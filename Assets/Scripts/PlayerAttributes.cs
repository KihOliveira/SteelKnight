using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerAttributes : MonoBehaviour {
    [SerializeField] private int hp;
    [SerializeField] private int maxHp = 3;
    [SerializeField] private float speed;
    static private int upgradeLevel = 1;
    [SerializeField] private bool isInvulnerable;   // 0 = nao  1 = sim
    private CapsuleCollider2D collider;
    private SpriteRenderer sR;
    [SerializeField] private Sprite SpriteDanger;
    [SerializeField] private Sprite SpriteHalf;
    [SerializeField] private Sprite SpriteFull;
    [SerializeField] private GameObject destroyedEffect;
    static public int lives = 3;
    
    private void Start() {
        SetHP(GetMaxHP());
        collider = gameObject.GetComponent<CapsuleCollider2D>();
        sR = gameObject.GetComponent<SpriteRenderer>();
        sR.enabled = true;
        FindObjectOfType<LifeCounter>().updateLifeCounter(lives);
        lives = 3;
        
    }

    private void Update() {
        
    }

//Funcoes
    public void TakeDamage(){
        this.hp -= 1;
        if(hp <= 0 ){
            DestroyPlayer();
        }else{
            SetSprite(hp);
            Invulnerability();
        }
        if(upgradeLevel > 1){
            upgradeLevel--;
        }
        
    }

    public void HealDamage(){
        if(hp<3){
            this.hp += 1;
            SetSprite(hp);
        }else{
            lives++;
            FindObjectOfType<LifeCounter>().updateLifeCounter(lives);
        }
    }

    public void Invulnerability(){
        collider.enabled = false;
        isInvulnerable = true;
        StartCoroutine(InvulnerabilityCD());
        if(isInvulnerable){
            StartCoroutine(InvulnerabilityFlick());
        }
    }

    IEnumerator InvulnerabilityCD(){
        yield return new WaitForSeconds(2f);
        collider.enabled = true;
        isInvulnerable = false;
        sR.enabled = true;
    }

    IEnumerator InvulnerabilityFlick(){
        while(isInvulnerable){
            sR.enabled = true;
            yield return new WaitForSeconds(0.25f);
            sR.enabled = false;
            yield return new WaitForSeconds(0.1f);
            sR.enabled = true;
        }
    }


    private void SetSprite(int life){
        if(life == 1) {
            sR.sprite = SpriteDanger;
        }else if(life == 2) {
            sR.sprite = SpriteHalf;
        }else {
            sR.sprite = SpriteFull;
        }
    }
    
    IEnumerator DestroyedAnimation(){
        sR.enabled = false;
        collider.enabled = false;
        GameObject effect = Instantiate(destroyedEffect, gameObject.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.4f);
        Destroy(effect);
        yield return new WaitForSeconds(0.15f);
        sR.enabled = true;
        yield return new WaitForSeconds(1f);
        collider.enabled = true;
    }

    public void DestroyPlayer(){
        lives--;
        FindObjectOfType<LifeCounter>().updateLifeCounter(lives);
        if(lives > 0){
            hp = 3;
            sR.sprite = SpriteFull;
            upgradeLevel = 1;
            StartCoroutine(DestroyedAnimation());
        }else{
            StartCoroutine(DestroyedAnimation());
            FindObjectOfType<GameManager>().GameOver();
        }
    }

//Setters e Getters
    public void SetHP(int life){
        this.hp = life;
    }

    public int GetHP(){
        return this.hp;
    }

    public void SetMaxHP(int life){
        this.maxHp = life;
    }

    public int GetMaxHP(){
        return this.maxHp;
    }

    public void SetSpeed(float speed){
        this.speed = speed;
    }

    public float GetSpeed(){
        return this.speed;
    }
    public void IncUpgradeLevel(){
        if(upgradeLevel<3){
            upgradeLevel++;
        }
    }

    public int GetUpgradeLevel(){
        return upgradeLevel;
    }

    public int GetLives(){
        return lives;
    }

    public void IncrementLives(){
        lives++;
    }
    
}