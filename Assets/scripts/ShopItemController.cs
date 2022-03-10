using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;

public class ShopItemController : MonoBehaviour
{
    public GameObject item;
    private ItemController itemController;

    public List<Color> list_couleur;

    // Start is called before the first frame update
    void Start()
    {
        itemController = item.GetComponent<ItemController>();

        transform.Find("Content/Content/NomItem").GetComponent<TMPro.TextMeshProUGUI>().text = itemController.nom;
        transform.Find("Content/Content/NomItem").GetComponent<TMPro.TextMeshProUGUI>().color = list_couleur[itemController.unlockPalier-1];
        transform.Find("Content/Content/ItemImage").GetComponent<UnityEngine.UI.Image>().sprite = itemController.image;
        transform.Find("Content/Content/TextProd").GetComponent<TMPro.TextMeshProUGUI>().text = "Produit " + TroueurGlobal.formatString(itemController.trouParTick) + " trous par tick";
        transform.Find("Content/Content/TextTick").GetComponent<TMPro.TextMeshProUGUI>().text = "Tick toute les " + itemController.tickDelay + " secondes";
        transform.Find("Content/Content/TextRenta").GetComponent<TMPro.TextMeshProUGUI>().text = System.Math.Round(itemController.trouParTick.BigInteger / itemController.tickDelay, 2) + " trous/s ";
        if(itemController.incrementTrousParClick.BigInteger > 0)
            transform.Find("Content/Content/TextTrouParClick").GetComponent<TMPro.TextMeshProUGUI>().text = " + " + itemController.incrementTrousParClick + " trous par click";
        else
            transform.Find("Content/Content/TextTrouParClick").GetComponent<TMPro.TextMeshProUGUI>().text = "";
        foreach (Transform child in transform.Find("Boutons")) {
            Debug.Log("moo");
            child.GetComponent<achatItemController>().item = item;
        }

    }

    // Update is called once per frame
    void Update()
    {
        transform.Find("Content/Content/TextPrix").GetComponent<TMPro.TextMeshProUGUI>().text = "Prix : " + TroueurGlobal.formatString(itemController.get_prix(1)) + " trous";
        transform.Find("Content/Content/Image/QuantitePossedé").GetComponent<TMPro.TextMeshProUGUI>().text = "#" + TroueurGlobal.formatString(itemController.quantite);
    }
}
