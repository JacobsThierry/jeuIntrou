using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textTrousfois2manager : MonoBehaviour
{
    private TMPro.TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMPro.TextMeshProUGUI>();
        text.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        text.enabled = heatManager.plancheFois2();
    }

    private void OnDisable() {
        text.enabled = false;
    }

    private void OnEnable() {
        text = GetComponent<TMPro.TextMeshProUGUI>();
        text.enabled = false;
    }

}
