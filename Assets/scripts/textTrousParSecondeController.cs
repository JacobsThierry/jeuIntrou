using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textTrousParSecondeController : MonoBehaviour
{

    private TMPro.TextMeshProUGUI text;

    private void updateText() {
        text = GetComponent<TMPro.TextMeshProUGUI>();
        text.text = "Trous par secondes : " + TroueurGlobal.formatString(TroueurGlobal.getTrousParSeconde());
    }

    private void Start() {
        updateText();
    }

    private void OnEnable() {
        updateText();
    }
}
