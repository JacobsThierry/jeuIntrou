using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class boutonMenuController : MonoBehaviour
{


    public void onClick() {
        GameObject.Find("soundManager").GetComponent<soundManagerController>().playSelect();
        SceneManager.LoadScene("Menu");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
