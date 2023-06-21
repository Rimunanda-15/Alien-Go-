using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private GameObject player;
    private Transform mainCam;
    public GameObject bullet;
    private bool autoShootOn = false;
    private float shootingRate = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        mainCam = GameObject.Find("Main Camera").GetComponent<Transform>();

        StartCoroutine(AutoShoot());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator AutoShoot()
    {
        while(true)
        {
            yield return new WaitForSeconds(shootingRate);

            if(autoShootOn)
            {
                Instantiate(bullet, mainCam.position, mainCam.rotation);
                player.GetComponent<AudioSource>().Play();
            }
        }
    }

    public void TurnOnAutoShoot()
    {
        autoShootOn = true;
    }

    public void TurnOffAutoShoot()
    {
        autoShootOn = false;
    }
}
