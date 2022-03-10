using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;

public class ecranPalierController : MonoBehaviour
{

    private TMPro.TextMeshProUGUI description;
    private TMPro.TextMeshProUGUI prix;
    private PalierManager palierManager;

    [TextArea(15,20)]
    public string textPalier3;



    private void Awake() {
        description = transform.Find("Description item").gameObject.GetComponent<TMPro.TextMeshProUGUI>();
        prix = transform.Find("Text prix").GetComponent<TMPro.TextMeshProUGUI>();
        palierManager = GameObject.Find("items and upgrades").GetComponent<PalierManager>();

        if (PalierManager.palier < palierManager.paliers.Count) { 
    //    description.text = palierManager.paliers[PalierManager.palier].desc;
            prix.text = "Cette amélioration te coûtera " + TroueurGlobal.formatString((long)palierManager.paliers[PalierManager.palier].prix.BigInteger) + " trous et réinitialisera tous tes achats.";
        }else {
            description.text = "Bravo, tu es arrivé au dernier palier";
            prix.text = "";
            transform.Find("BoutonCodes").gameObject.SetActive(false);
        }

        if (PalierManager.palier == 3) {
            transform.Find("Explications").GetComponent<TMPro.TextMeshProUGUI>().text = textPalier3;
        }

    }

    public void onClick() {

        

        if (TroueurGlobal.nbTrous >= (palierManager.paliers[PalierManager.palier].prix)) {
            TroueurGlobal.nbTrous = 0;
            GameObject.Find("soundManager").GetComponent<soundManagerController>().playPiouPiou();
            foreach (Transform child in GameObject.Find("Items").transform) {
                child.GetComponent<ItemController>().quantite = 0;
            }
            foreach (Transform child in GameObject.Find("items and upgrades").transform.Find("Upgrades"))
            {
                upgradeController uc = child.GetComponent<upgradeController>();


                if (!uc.cache) {
                    uc.reset();
                    uc.achete = false;
                }
            }

            PalierManager.palier += 1;
            rainController.instance.resetMax();
            Debug.Log("Nouveau palier = " + palierManager.paliers);
            Awake();
            TroueurGlobal.baseTrouIncrement = 1;
        }else {
            GameObject.Find("soundManager").GetComponent<soundManagerController>().playHit();
        }
    }


    private void Update() {
        transform.Find("BoutonPalier").GetComponent<UnityEngine.UI.Button>().interactable = TroueurGlobal.nbTrous >= palierManager.paliers[PalierManager.palier].prix;
    }

}
