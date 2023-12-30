using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLogic : MonoBehaviour
{
    [SerializeField] private int partsNumber;
    [SerializeField] private bool isFinalBoss;

   void Update()
    {
        if(partsNumber == 0){
            Destroyed();
        }
    }

    public void ReducePartsNumber(){
        partsNumber--;
    }

    public void Destroyed(){
        if(isFinalBoss){
            FindObjectOfType<GameManager>().GameOver();
        }else{
            FindObjectOfType<GameManager>().isBossDefeated = true;
            FindObjectOfType<DoorLogic>().LevelComplete();
            Destroy(gameObject);
        }
        
    }

    public int GetParts(){
        return partsNumber;
    }
}
