using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class piouPiouBulleController : MonoBehaviour
{

    private void OnEnable() {
        GameObject.Find("soundManager").GetComponent<soundManagerController>().playPiouPiou();
    }

}
