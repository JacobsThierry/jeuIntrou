using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;
public class heatManager : MonoBehaviour
{


    public static float clickParSeconde = 0f;

    private static float heat = 0f;

    public static float baseHeatDifficulty = 4f;
    public static float heatDifficulty;

    public static UnityEvent click = new UnityEvent();

    public static float comboDuration = 0f;

    private static float heatResetLengh = 2f;

    private static float heatResetTimer = 0f;
    private static float heatResetSpeed = 0.2f;

    private static float timerCombo = 0f;

    private float comboLength = 1f;

    private float comboStart = 0.95f;

    private float comboEnd = 0.90f;


    private float slowDown = 50f;

    private float malusFois2 = 0.3f;



    private void OnDisable() {
        heatDifficulty = 0;
        heatResetTimer = 0;
        heat = 0;
        timerCombo = 0;
    }

    private void OnEnable() {
        heatDifficulty = 0;
        heatResetTimer = 0;
        heat = 0;
        timerCombo = 0;
    }


    // Start is called before the first frame update
    void Start()
    {
        click.AddListener(clickFunc);
    }

    void clickFunc()
    {
        heatResetTimer = heatResetLengh;
    }

    // Update is called once per frame
    void Update()
    {
        heatDifficulty = baseHeatDifficulty * getHeat();

        if (clickParSeconde > 0.01)
        {

            clickParSeconde *= 1 - Time.deltaTime;

        }
        //Debug.Log("cps = " + clickParSeconde);

        heatResetTimer -= heatResetTimer < 0 ? 0 : Time.deltaTime;

        //Debug.Log("Time = " + heatResetTimer);

        if (heatResetTimer < 0)
        {
            Debug.Log("koo");
            heat -= heat > 0 ? 0 : (heatResetSpeed * Time.deltaTime);
        }

        heat += ((clickParSeconde - (heatDifficulty + malus())) * (Time.deltaTime / slowDown)) 
        * (1/Mathf.Max(1,(Input.touchCount>0?Input.touchCount:1)));

        if (heat < 0) heat = 0;

        //Debug.Log("Heat = " + heat);
        Debug.Log("Heat01 = " + getHeat01());

        Debug.Log("timer Combo = " + timerCombo);

        if ((timerCombo <= 0 && getHeat01() > comboStart) || (timerCombo > 0 && getHeat01() > comboEnd))
        {
            timerCombo = comboLength;
        }

        comboDuration += plancheFois2() ? Time.deltaTime/2 : (comboDuration>0?-Time.deltaTime/4:0f);

        timerCombo -= timerCombo > 0 ? Time.deltaTime :0;


    }

    private float malus() {
        Debug.Log("Malus = " + (malusFois2 * comboDuration));
        Debug.Log("Malus Duration = " + comboDuration);
        return malusFois2 * comboDuration;
    }


    public static bool plancheFois2()
    {
        Debug.Log("planchFois2 = " + (timerCombo > 0));
        return timerCombo > 0;

    }

    

    public static float getHeat() {
        return heat;
    }

    public static float getHeat01() {
        
        return Mathf.Min(getHeat()/3 , 1);
    }


}
