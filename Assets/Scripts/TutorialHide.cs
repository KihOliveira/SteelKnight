using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialHide : MonoBehaviour
{
    private SpriteRenderer sR;
    private float counter = 8f;
    private float timer;
    void Start()
    {
        sR = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        timer = Time.deltaTime;
        if(timer > counter){
            sR.enabled = false;
        }
    }


}
