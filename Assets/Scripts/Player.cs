using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    private int healthPoint;
    private GameObject gameManager;
    public GameObject hpTextObject;
    public GameObject powerUpTextObject;
    private TMP_Text hpText;
    private bool isPowerUpOn;

    // Start is called before the first frame update
    void Start()
    {
        isPowerUpOn = false;
        healthPoint = 25;
        gameManager = GameObject.Find("Game Manager");
        hpText = hpTextObject.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void decreaseHp(int damage)
    {
        int newHealthPoint = healthPoint - damage;
        SetPlayerHp(newHealthPoint);
        if(healthPoint <= 0)
        {
            gameManager.GetComponent<GameManagerX>().GameOver();
        }
    }

    public void SetPlayerHp(int inputHealthPoint)
    {
        healthPoint = inputHealthPoint;
        if(healthPoint >= 0)
        {
            hpText.text = healthPoint.ToString();
        } 
        else
        {
            hpText.text = "0";
        }
    }

    public void GetPowerUp()
    {
        StartCoroutine(GetPowerUpHelper());
    }

    IEnumerator GetPowerUpHelper()
    {
        isPowerUpOn = true;
        powerUpTextObject.SetActive(true);

        yield return new WaitForSecondsRealtime(1f);

        powerUpTextObject.SetActive(false);

        yield return new WaitForSecondsRealtime(15f);

        isPowerUpOn = false;
    }

    public bool GetPowerUpStatus()
    {
        return isPowerUpOn;
    }    
}
