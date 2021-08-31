using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class boutonMagasinController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void onClick() {
        GameObject.Find("soundManager").GetComponent<soundManagerController>().playSelect();
        GameObject.Find("items and upgrades").GetComponent<save>().saveAll();
        SceneManager.LoadScene("shop");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
