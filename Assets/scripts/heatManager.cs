using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;
public class heatManager : MonoBehaviour
{

    public static float heat = 0f;
    public static float clickParSeconde = 0f;

    private static float clickIntensity = 0f;

    public static float heatDifficulty = 7f;

    public static UnityEvent click= new UnityEvent();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(clickParSeconde > 0) clickParSeconde *= 1 - Time.deltaTime;
        
        clickIntensity += (clickParSeconde - heatDifficulty) * Time.deltaTime;

        if(clickIntensity < 0) clickIntensity = 0;

        Debug.Log("heat = " + clickIntensity.ToString());
    }


    public static float getHeat01() {
        return Mathf.Min(clickIntensity/(heatDifficulty*10) , 1);
    }


}
