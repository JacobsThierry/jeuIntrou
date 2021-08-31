using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class boutonRetourController : MonoBehaviour
{

    public GameObject ShopButtons;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void onClick() {
        GameObject.Find("soundManager").GetComponent<soundManagerController>().playSelect();
        GameObject.Find("items and upgrades").GetComponent<save>().saveAll();

        if (GameObject.Find("ShopButtons") == null) {
            SceneManager.LoadScene("shop");

        }else {
            SceneManager.LoadScene("GameScene");
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
