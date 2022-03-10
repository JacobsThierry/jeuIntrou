using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetObjectController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("items and upgrades").GetComponent<save>().resetAll();
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
