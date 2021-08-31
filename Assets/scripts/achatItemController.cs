using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class achatItemController : MonoBehaviour
{

    public int quantite = 1;
    public GameObject item;
    private ItemController itemController;

    private UnityEngine.UI.Button button;




    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<UnityEngine.UI.Button>();
        
    }

    public void onClick() {
        if (TroueurGlobal.nbTrous >= itemController.get_prix(quantite)) {
            TroueurGlobal.nbTrous -= itemController.get_prix(quantite);
            itemController.quantite += quantite;
            GameObject.Find("soundManager").GetComponent<soundManagerController>().playBuy();
            GameObject.Find("items and upgrades").GetComponent<save>().saveAll();
        }
    }

    // Update is called once per frame
    void Update()
    {
        itemController = item.GetComponent<ItemController>();
        button.interactable = TroueurGlobal.nbTrous >= itemController.get_prix(quantite);

    }
}
