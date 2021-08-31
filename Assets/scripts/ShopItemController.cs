using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItemController : MonoBehaviour
{
    public GameObject item;
    private ItemController itemController;
    // Start is called before the first frame update
    void Start()
    {
        itemController = item.GetComponent<ItemController>();

        transform.Find("Content/Content/NomItem").GetComponent<TMPro.TextMeshProUGUI>().text = itemController.nom;
        transform.Find("Content/Content/ItemImage").GetComponent<UnityEngine.UI.Image>().sprite = itemController.image;
        transform.Find("Content/Content/Image/QuantitePossedé").GetComponent<TMPro.TextMeshProUGUI>().text = "#" + itemController.quantite.ToString();
        transform.Find("Content/Content/TextProd").GetComponent<TMPro.TextMeshProUGUI>().text = "Produit " + itemController.trouParTick.ToString() + " trous par tick";
        transform.Find("Content/Content/TextTick").GetComponent<TMPro.TextMeshProUGUI>().text = "Tick toute les " + itemController.tickDelay + " secondes";
        transform.Find("Content/Content/TextPrix").GetComponent<TMPro.TextMeshProUGUI>().text = "Prix : " + itemController.getPrix() + " trous";

        foreach (Transform child in transform.Find("Boutons")) {
            Debug.Log("moo");
            child.GetComponent<achatItemController>().item = item;
        }

    }

    // Update is called once per frame
    void Update()
    {
        transform.Find("Content/Content/TextPrix").GetComponent<TMPro.TextMeshProUGUI>().text = "Prix : " + itemController.getPrix() + " trous";
        transform.Find("Content/Content/Image/QuantitePossedé").GetComponent<TMPro.TextMeshProUGUI>().text = "#" + itemController.quantite.ToString();
    }
}
