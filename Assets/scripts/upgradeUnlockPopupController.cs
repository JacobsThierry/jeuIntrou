using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgradeUnlockPopupController : MonoBehaviour
{

    public GameObject item;
    public RectTransform panelRectTransform;

    // Start is called before the first frame update
    void Start()
    {
        upgradeController up = item.GetComponent<upgradeController>();

        if (!up.achete) { 

            transform.Find("popup/Content/Content/nomItem").GetComponent<TMPro.TextMeshProUGUI>().text = "Débloqué : " + up.nom;
            transform.Find("popup/Content/Content/descItem").GetComponent<TMPro.TextMeshProUGUI>().text = item.GetComponent<upgradeController>().description;
            transform.Find("popup/Content/Content/Image").GetComponent<UnityEngine.UI.Image>().sprite = item.GetComponent<upgradeController>().image;
        }else {
            transform.Find("popup/Content/Content/nomItem").GetComponent<TMPro.TextMeshProUGUI>().text = up.nom;
            transform.Find("popup/Content/Content/descItem").GetComponent<TMPro.TextMeshProUGUI>().text = "Tu as déjà débloqué cet item !";
            transform.Find("popup/Content/Content/Image").GetComponent<UnityEngine.UI.Image>().sprite = item.GetComponent<upgradeController>().image;
        }
    }

    public void onClick()
    {
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
