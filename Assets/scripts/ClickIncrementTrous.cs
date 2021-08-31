using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickIncrementTrous : MonoBehaviour
{


    public void onClick() {
        GameObject.Find("soundManager").GetComponent<soundManagerController>().playHit();
        TroueurGlobal.nbTrous += TroueurGlobal.getIncrement();
        this.GetComponent<ClickEffetTrou>().quantiteParticleTrous = Mathf.Log( (float) (TroueurGlobal.getIncrement()) + 0.75f);
        heatManager.clickParSeconde += 1;
    }

}
