using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemies : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject theEnemie1;
    public GameObject theEnemie2;
    public GameObject theEnemie3;
    public GameObject player;
    public int xPos1;
    public int xPos2;
    public int xPos3;
    public int yPos;
    public int zPos;
    public int enemyCount;

    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop(){
        while (enemyCount < 10){
            xPos1 = Random.Range(-20, 20);
            xPos2 = Random.Range(-15, 15);
            xPos3 = Random.Range(-10, 10);
            yPos = Random.Range(-5, 12);
            zPos = Random.Range(6, 15);
            Instantiate (theEnemie1, new Vector3(xPos1, yPos, zPos), Quaternion.identity);
            Instantiate (theEnemie3, new Vector3(xPos2, yPos, zPos), Quaternion.identity);
            Instantiate (theEnemie2, new Vector3(xPos3, yPos, zPos), Quaternion.identity);
            yield return new WaitForSeconds(3);
            enemyCount =+ 1;
        }
    }
}