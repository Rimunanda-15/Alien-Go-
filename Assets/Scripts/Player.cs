using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int healthPoint;
    private GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        healthPoint = 0;
        gameManager = GameObject.Find("Game Manager");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void decreaseHp(int damage)
    {
        healthPoint -= damage;
        Debug.Log("Player HP: " + healthPoint);
        if(healthPoint <= 0)
        {
            gameManager.GetComponent<GameManagerX>().GameOver();
        }
    }

    public void SetPlayerHp(int inputHealthPoint)
    {
        healthPoint = inputHealthPoint;
    }
}
