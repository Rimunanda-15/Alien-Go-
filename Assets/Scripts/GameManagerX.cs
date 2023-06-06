using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerX : MonoBehaviour
{
    public GameObject player;
    private bool isGameActive;
    private int score;

    // enemy spawner variables
    public GameObject[] enemies;
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

    // Start is called before the first frame update
    void Start()
    {
        DisplayMainMenu();
        StartCoroutine(SpawnEnemy());
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
    }

    public void RestartGame()
    {
        DestroyAllEnemies();
        PlayGame();
    }

    public void GameOver()
    {
        isGameActive = false;
        Debug.Log("Game is non-active");

        // set game over panel to true
        mainMenuPanel.SetActive(false);
        creditPanel.SetActive(false);
        aboutPanel.SetActive(false);
        exitPanel.SetActive(false);
        gameOverPanel.SetActive(true);
    }

    public void DisplayMainMenu()
    {
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
            yield return new WaitForSeconds(4);
        }
    }

    void SpawnEnemyHelper()
    {
        if(isGameActive)
        {
            xPos1 = Random.Range(-20, 20);
            xPos2 = Random.Range(-15, 15);
            xPos3 = Random.Range(-10, 10);
            yPos = Random.Range(-5, 12);
            zPos = Random.Range(6, 15);
            int enemyIndex = Random.Range(0, 3);
            Instantiate (enemies[enemyIndex], new Vector3(xPos1, yPos, zPos), Quaternion.identity);
        }
    }

    void DestroyAllEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
    }
}
