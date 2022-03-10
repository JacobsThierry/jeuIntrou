using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadCanvas : MonoBehaviour
{

    public GameObject canvas;
    public GameObject items;

    public void load() {
        canvas.SetActive(true);
        items.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
