using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpawnState {SPAWNING, WAITING, COUNTING, END};

public class WaveSpawner : MonoBehaviour {
    [SerializeField] private int enemyMaxAmount = 4;    // Valor inicial do numero de inimigos a serem spawnados por wave
    public Transform[] spawnPoints; // Array dos spawnpoints no mapa
    public Transform[] enemiesTypes;    // Array de tipos de inimigos
    public float timeBetweenWaves = 5f;
    public float waveCountdown;
    private SpawnState state ;
    private GameManager gm;
    void Start() {
        waveCountdown = timeBetweenWaves; // Inicia a primeira wave em 5s.
        gm = FindObjectOfType<GameManager>();
    }

    void Update() {

        if(gm.isBossSpawned){
            state = SpawnState.COUNTING;
        }

        if(gm.isBossDefeated){
            state = SpawnState.END;
        }

        if (state == SpawnState.WAITING) { 
            Debug.Log("Wave concluida");
            state = SpawnState.COUNTING;
            waveCountdown = timeBetweenWaves;
        }

        if (waveCountdown <= 0) { //
            if(state != SpawnState.SPAWNING && state != SpawnState.END) {
                StartCoroutine(SpawnWave());
                waveCountdown = timeBetweenWaves;
            }
        }
        else if(state != SpawnState.END) {
            waveCountdown -= Time.deltaTime;
        }
    }

    IEnumerator SpawnWave() {
        state = SpawnState.SPAWNING;    //Altera o estado para spawnando
        for(int i = 0; i < enemyMaxAmount; i++) {     // Enquanto i < qntdd maxima de inimigos da wave faça:  
            SpawnEnemy(enemiesTypes[Random.Range(0, enemiesTypes.Length)]);     // Spawna um tipo aleatorio de inimigo dentro do limite dos disponiveis
            yield return new WaitForSeconds(1f);  // Espera alguns segundos antes de spawnar de novo
        }
        state = SpawnState.WAITING;
        Debug.Log(state);
        yield break;
    }

    void SpawnEnemy(Transform enemy) { 
        Transform spawnP = spawnPoints[Random.Range(0, spawnPoints.Length)];    // Spawna em um ponto aleatorio
        Instantiate(enemy, spawnP.position, spawnP.rotation);
    }

}
