using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    TimerController timerController;
    [SerializeField] GameObject timer;

    public GameObject enemyPref;
    private float spawnRangeX = 9.0f;
    private float spawnRangeZ = 4.0f;
    public int waveNumber = 0;
    public int enemyCount;
    private bool isWaveTime = false;
    public TextMeshProUGUI waveText;

    private void Awake()
    {
        timerController = timer.GetComponent<TimerController>();
    }

    void Start()
    {

        SpawnUpdate();
        timerController.max_time = 50.0f;

    }

    private void Update()
    {
        SpawnUpdate();
    }

    private Vector3 GenerateRandomPosition()
    {
        float spawnPosX = Random.Range(-spawnRangeX, spawnRangeX);
        float spawnPosZ = Random.Range(-spawnRangeZ, spawnRangeZ);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }

    void SpawnUpdate()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0 && isWaveTime == false)
        {

            isWaveTime = true;
            StartCoroutine("WaveTime");
            timerController.max_time -= 5;
            Debug.Log(timerController.max_time);
        }
    }

    void SpawnEnemy(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            
            Instantiate(enemyPref, GenerateRandomPosition(), enemyPref.transform.rotation);
        }
    }

    IEnumerator WaveTime()
    {
        waveNumber++;
        waveText.text = "Wave " + waveNumber.ToString();
        waveText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        waveText.gameObject.SetActive(false);
        SpawnEnemy(waveNumber);
        isWaveTime = false;

    }
}
