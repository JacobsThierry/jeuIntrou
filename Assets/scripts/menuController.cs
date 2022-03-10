using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuController : MonoBehaviour
{
    private GameObject dontDestroyOnload;
    // Start is called before the first frame update
    void Start()
    {
        dontDestroyOnload = GameObject.Find("DontDestroyOnLoadObject");
        dontDestroyOnload.GetComponent<loadCanvas>().load();
        GameObject.Find("soundManager").GetComponent<soundManagerController>().setupMusique();
    }

    // Update is called once per frame
    void Update()
    {
        if (dontDestroyOnload == null) {
            GameObject.Find("DontDestroyOnLoadObject");
        }else {
            dontDestroyOnload.GetComponent<loadCanvas>().load();
        }
    }
}
