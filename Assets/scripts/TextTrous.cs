﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTrous : MonoBehaviour
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
        text.text = TroueurGlobal.getNbTrous() + " Trous";



    }
}
