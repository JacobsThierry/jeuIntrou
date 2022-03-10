using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopUpgradeController : MonoBehaviour
{

    public GameObject upgrade;
    private upgradeController controller;

    public List<Color> list_couleur;


    // Start is called before the first frame update
    void Start()
    {
        controller = upgrade.GetComponent<upgradeController>();

        transform.Find("Content/Content/NomUpgrade").GetComponent<TMPro.TextMeshProUGUI>().text = controller.nom;
        transform.Find("Content/Content/NomUpgrade").GetComponent<TMPro.TextMeshProUGUI>().color = list_couleur[controller.unlockPalier - 1];
        transform.Find("Content/Content/UpgradeImage").GetComponent<UnityEngine.UI.Image>().sprite = controller.image;
        transform.Find("Content/Content/TextEffets").GetComponent<TMPro.TextMeshProUGUI>().text = controller.textEffets;
        transform.Find("Content/Content/DescriptionUpgrade").GetComponent<TMPro.TextMeshProUGUI>().text = controller.description;
        transform.Find("Content/Content/PrixUpgrade").GetComponent<TMPro.TextMeshProUGUI>().text = "Prix :" + TroueurGlobal.formatString(controller.prix);
    }

    // Update is called once per frame
    void Update()
    {
        
        GameObject so = transform.Find("Sold out").gameObject;
        so.SetActive(controller.achete);
        transform.Find("Content/Content/Boutons/Button").GetComponent<UnityEngine.UI.Button>().interactable = !(controller.achete) && (TroueurGlobal.nbTrous >= controller.prix);

    }

    public void acheterUpgrade() {
        if (TroueurGlobal.nbTrous >= controller.prix) {
            TroueurGlobal.nbTrous -= controller.prix;
            GameObject.Find("soundManager").GetComponent<soundManagerController>().playSelect();
            controller.achete = true;


        }
        GameObject.Find("items and upgrades").GetComponent<save>().saveAll();
    }

}
