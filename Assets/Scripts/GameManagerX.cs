using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerX : MonoBehaviour
{
    private Transform mainCam;
    public GameObject bullet;
    private bool autoShootOn = false;
    private float shootingRate = 0.3f;
    private GameObject cube;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.Find("Main Camera").GetComponent<Transform>();

        cube = GameObject.Find("Cube");
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
