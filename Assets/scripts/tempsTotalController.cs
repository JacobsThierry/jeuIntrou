using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class tempsTotalController : MonoBehaviour
{
    private TMPro.TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMPro.TextMeshProUGUI>();
        
    }

    // Update is called once per frame
    void Update()
    {
        TimeSpan time = TimeSpan.FromSeconds(TroueurGlobal.tempsDeJeu);
        text.text = time.ToString("hh':'mm':'ss");
    }
}
