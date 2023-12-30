using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShieldCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text shieldCounter;
    public void updateShieldCounter(int shield) {
        string counterString = "x"+shield;
        shieldCounter.text = counterString;
    }
}
