using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour {
    [SerializeField] private TMP_Text scoreText;
    static private int scoreValue;
    
    void Update() {
        updateScore();
    }

    public void addScore(int score) {
        scoreValue += score;
    }

    private void updateScore() {
        string scoreString = "Score: "+scoreValue;
        scoreText.text = scoreString;
    }
}
