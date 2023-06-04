using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemies : MonoBehaviour
{
    public GameObject[] enemies;
    public int xPos1;
    public int xPos2;
    public int xPos3;
    public int yPos;
    public int zPos;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy(){
        while (true)
        {
            xPos1 = Random.Range(-20, 20);
            xPos2 = Random.Range(-15, 15);
            xPos3 = Random.Range(-10, 10);
            yPos = Random.Range(-5, 12);
            zPos = Random.Range(6, 15);
            int enemyIndex = Random.Range(0, 3);
            Instantiate (enemies[enemyIndex], new Vector3(xPos1, yPos, zPos), Quaternion.identity);
            yield return new WaitForSeconds(3);
        }
    }
}