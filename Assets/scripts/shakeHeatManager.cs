using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shakeHeatManager : MonoBehaviour
{

    public float shakeIntensity;
    public float baseShake;

    private objectShake shaker;


    // Start is called before the first frame update
    void Start()
    {
        heatManager.click.AddListener(shake);
        shaker = GetComponent<objectShake>();
    }

    void shake() {
        shaker.shake_intensity = heatManager.getHeat() * shakeIntensity + baseShake;
        Debug.Log("heat = " + heatManager.getHeat());
        shaker.Shake();
    }

}
