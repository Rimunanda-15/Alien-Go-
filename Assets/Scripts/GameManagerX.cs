using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ilumisoft.RadarSystem;

public class GameManagerX : MonoBehaviour
{
    public GameObject player;
    private bool isGameActive;
    private int score;

    // enemy spawner variables
    public GameObject[] enemies;
    private float regularEnemySpawnCooldown = 5f;
    private float powerUpEnemySpawnCooldown = 30f;
    private int xPos1;
    private int xPos2;
    private int xPos3;
    private int yPos;
    private int zPos;

    // UI panels
    public GameObject mainMenuPanel;
    public GameObject creditPanel;
    public GameObject aboutPanel;
    public GameObject exitPanel;
    public GameObject gameOverPanel;
    public GameObject mainCanvas;
    public GameObject overlayCanvas;
    public GameObject radar;

    // powerups
    public GameObject keris;
    public GameObject powerUpAsteroid;

    // Start is called before the first frame update
    void Start()
    {
        isGameActive = false;
        DisplayMainMenu();
        StartCoroutine(SpawnEnemy());
        StartCoroutine(SpawnEnemyWithPowerUp());
        score = 0; 
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void PlayGame()
    {
        isGameActive = true;
        player.GetComponent<Player>().SetPlayerHp(25);
        Debug.Log("Game is active");

        // set all UI panel to invisible
        mainMenuPanel.SetActive(false);
        creditPanel.SetActive(false);
        aboutPanel.SetActive(false);
        exitPanel.SetActive(false);
        gameOverPanel.SetActive(false);

        // change canvas to overlay
        mainCanvas.SetActive(false);
        overlayCanvas.SetActive(true);
        radar.SetActive(true);
    }

    public void RestartGame()
    {
        PlayGame();
    }

    public void GameOver()
    {
        isGameActive = false;
        StartCoroutine(DestroyAllEnemies());
        Debug.Log("Game is non-active");

        // change canvas to main
        mainCanvas.SetActive(true);
        overlayCanvas.SetActive(false);

        // set game over panel to true
        mainMenuPanel.SetActive(false);
        creditPanel.SetActive(false);
        aboutPanel.SetActive(false);
        exitPanel.SetActive(false);
        gameOverPanel.SetActive(true);
    }

    public void DisplayMainMenu()
    {
        // set canvas to main
        mainCanvas.SetActive(true);
        overlayCanvas.SetActive(false);
        radar.SetActive(false);

        mainMenuPanel.SetActive(true);
        creditPanel.SetActive(false);
        aboutPanel.SetActive(false);
        exitPanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            SpawnEnemyHelper();
            yield return new WaitForSecondsRealtime(regularEnemySpawnCooldown);
        }
    }

    IEnumerator SpawnEnemyWithPowerUp()
    {
        while(true)
        {
            yield return new WaitForSecondsRealtime(powerUpEnemySpawnCooldown);
            SpawnEnemyHelper(true);
        }
    }

    void SpawnEnemyHelper(bool withPowerUp = false)
    {
        if(isGameActive)
        {
            xPos1 = Random.Range(-20, 20);
            xPos2 = Random.Range(-15, 15);
            xPos3 = Random.Range(-10, 10);
            yPos = Random.Range(-5, 12);
            zPos = Random.Range(6, 15);
            if(!withPowerUp)
            {
                int enemyIndex = Random.Range(0, 3);
                Instantiate(enemies[enemyIndex], new Vector3(xPos1, yPos, zPos), Quaternion.identity);
            } else
            {
                Instantiate(powerUpAsteroid, new Vector3(xPos1, yPos, zPos), Quaternion.identity);
            }
        }
    }

    IEnumerator DestroyAllEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        yield return new WaitForSeconds(1f);

        foreach (GameObject enemy in enemies)
        {
            if(enemy != null)
            {
                enemy.GetComponent<Locatable>().ClampOnRadar = false;
                Destroy(enemy);
            }
        }

        radar.SetActive(false);
    }
}
