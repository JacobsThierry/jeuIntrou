using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trouParClickController : MonoBehaviour
{
    private TMPro.TextMeshProUGUI text;

    private void updateText() {
        text = GetComponent<TMPro.TextMeshProUGUI>();
        text.text = "Trous par click : " + TroueurGlobal.formatString(TroueurGlobal.getIncrement());
    }

    private void Start()
    {
        
    }

    private void OnEnable()
    {
        text = GetComponent<TMPro.TextMeshProUGUI>();
        text.text = "Trous par click : " + TroueurGlobal.formatString(TroueurGlobal.getIncrement());
    }
}
