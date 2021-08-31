using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class volumeController : MonoBehaviour
{

    public UnityEngine.UI.Slider mainSlider;

    public void onValueChange() {
        GameObject.Find("soundManager").GetComponent<soundManagerController>().volume = mainSlider.value;
    }

    // Start is called before the first frame update
    void Start()
    {
        mainSlider.value = GameObject.Find("soundManager").GetComponent<soundManagerController>().volume;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
