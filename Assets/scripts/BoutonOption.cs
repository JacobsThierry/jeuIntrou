using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoutonOption : MonoBehaviour
{

    public GameObject Options;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClick() {
        GameObject.Find("soundManager").GetComponent<soundManagerController>().playSelect();
        Instantiate(Options, transform.parent);
    }
}
