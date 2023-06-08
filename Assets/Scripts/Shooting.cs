using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private Transform mainCam;
    public GameObject bullet;
    private bool autoShootOn = false;
    private float shootingRate = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
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
