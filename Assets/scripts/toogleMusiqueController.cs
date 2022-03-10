using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toogleMusiqueController : MonoBehaviour
{


    soundManagerController soundManagerController;

    UnityEngine.UI.Toggle toggle;

    private void Start() {
        toggle = GetComponent<UnityEngine.UI.Toggle>();
        toggle.onValueChanged.AddListener(onValueChange);
        soundManagerController = GameObject.Find("soundManager").GetComponent<soundManagerController>();
        toggle.isOn = soundManagerController.musiqueOn;
    }


    public void onValueChange(bool b) {
        soundManagerController.musiqueOn = b;
        soundManagerController.playSelect();

    }

}
