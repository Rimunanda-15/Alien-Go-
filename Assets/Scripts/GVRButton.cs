using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GVRButton : MonoBehaviour
{
    public Image imgCircle;
    public UnityEvent GVRClick;
    private float totalTime;
    private bool gvrStatus;
    private float gvrTimer;

    // Start is called before the first frame update
    void Start()
    {
        totalTime = 3f;
        gvrStatus = false;
        gvrTimer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(gvrStatus)
        {
            gvrTimer += Time.deltaTime;
            imgCircle.fillAmount = gvrTimer / totalTime;
        }

        if(gvrTimer > totalTime)
        {
            imgCircle.fillAmount = 0f;
            gvrTimer = 0f;
            gvrStatus = false;
            GVRClick.Invoke();
        }
    }

    public void GvrOn()
    {
        gvrStatus = true;
    }

    public void GvrOff()
    {
        gvrStatus = false;
        gvrTimer = 0;
        imgCircle.fillAmount = 0f;
    }
}
