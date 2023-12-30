using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LifeCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text counterText;

    
    public void updateLifeCounter(int life) {
        string counterString = "x"+life;
        counterText.text = counterString;
    }
}
