using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public static GameManager gameManager;
    [SerializeField] private Scene actual;
    [SerializeField] private RawImage rmAlert;
    private bool isOcurring;
    [SerializeField] private int enemyAmount;
    [SerializeField] private GameObject boss;
    public bool isBossSpawned = false;
    public bool isBossDefeated = false;
    [SerializeField] private Transform bossSpawnPoint;
    private string firstLevel = "Level1";

    private void Start() {
        actual = SceneManager.GetActiveScene();
        rmAlert.enabled = false;
        enemyAmount = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    private void Update() {
        if(enemyAmount <= 0){
            Debug.Log("Spawnando boss");
            Instantiate(boss, bossSpawnPoint);
            isBossSpawned = true;
            Debug.Log("Boss Spawnado");
            StartCoroutine(AlertAnimation());
            StopCoroutine(AlertAnimation());
            enemyAmount = 99999;
        }
    }

    public void ReduceEnemyAmount(){
        enemyAmount--;
    }

    public int GetEnemyAmount(){
        return enemyAmount;
    }

    IEnumerator AlertAnimation(){
        rmAlert.enabled = true;
        yield return new WaitForSeconds(0.5f);
        rmAlert.enabled = false;
        yield return new WaitForSeconds(0.5f);
        rmAlert.enabled = true;
        yield return new WaitForSeconds(0.5f);
        rmAlert.enabled = false;
    }

    public void LoadNextLevel(string levelName){
        SceneManager.LoadScene(levelName);
    }

    public void GameOver() {
        SceneManager.LoadScene("End");
    }

    void ReturnToMenu() {
        SceneManager.LoadScene("MainMenu");
    }
    public void ReloadLevel(){
        SceneManager.LoadScene(actual.name);
    }
    public void Reset(){
        SceneManager.LoadScene(firstLevel);
    }

}
