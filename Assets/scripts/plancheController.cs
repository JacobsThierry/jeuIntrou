using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plancheController : MonoBehaviour
{

    public List<Sprite> planches;

    void updatePlanche() {
        GetComponent<UnityEngine.UI.Image>().sprite = planches[PalierManager.palier - 1];
    }


    private void Awake() {
        updatePlanche();
    }

    private void OnEnable() {
        updatePlanche();
    }

    private void Start() {
        updatePlanche();
    }

}
