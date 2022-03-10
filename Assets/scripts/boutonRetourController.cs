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

        Transform subScene = transform.parent.Find("shopSubScene");

        if (subScene.childCount == 0) {
            GameObject.Find("CanvasManager").GetComponent<CanvasManager>().activerCanvasJeu();
        }else {
            Destroy(subScene.GetChild(0).gameObject);
            GameObject a = Instantiate(ShopButtons, transform.parent);
            a.name = a.name.Replace("(Clone)", "");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
