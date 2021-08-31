using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetController : MonoBehaviour
{
    // Start is called before the first frame update

    public void onClick() {
        GameObject.Find("soundManager").GetComponent<soundManagerController>().playHit();
        GameObject.Find("items and upgrades").GetComponent<save>().resetAll();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
