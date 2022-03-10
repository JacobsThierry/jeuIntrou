using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class piouController : MonoBehaviour
{


    public GameObject textBonus;
    public float nbSecondeBonus;

    public void onClick() {
        long increment =(long)(TroueurGlobal.getTrousParSeconde() * nbSecondeBonus) + (nbSecondeBonus>0?10:-10);
        TroueurGlobal.nbTrous += increment;

        GameObject tb = Instantiate(textBonus, transform.position, Quaternion.identity, transform.parent.parent);
        tb.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text =  (increment>0?" + ":"") + TroueurGlobal.formatString(increment);

        if(increment > 0){

        GameObject.Find("soundManager").GetComponent<soundManagerController>().playPoorPiouPiou();
            TroueurGlobal.nbClickPiouPiou++;
        }else {
            GameObject.Find("soundManager").GetComponent<soundManagerController>().playHit();
            TroueurGlobal.nbClickPiege++;
            tb.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().color = Color.red;

        }
        
        Destroy(this.transform.parent.gameObject);
    }


}
