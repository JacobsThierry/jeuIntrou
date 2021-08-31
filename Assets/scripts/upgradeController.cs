using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgradeController : MonoBehaviour
{

    public int id;
    public string nom;

    [TextArea(15, 20)]
    public string textEffets;

    [TextArea(15, 20)]
    public string description;

    public long prix;

    public long incrementUpgradeBrut;

    


    [System.Serializable]
    public class effet {
        public long itemId;
        public long baseProdUpgrade;
        public long modificateurTrousParClick;
        public float speedModifier=1;
    }

    public Sprite image;

    public List<effet> effets;

    public bool achete;

    public bool cache = false;

    private bool applique = false;


private void Start() {

    }

    public void appliquer() {

        if (!this.applique) { 

        this.applique = true;

        GameObject items = GameObject.Find("Items");

        foreach (Transform child in items.transform) {
            ItemController controller = child.GetComponent<ItemController>();
            foreach (effet e in effets) {
                if (e.itemId == controller.id) {
                    controller.trouParTick += e.baseProdUpgrade;
                    controller.tickDelay *= e.speedModifier;
                    controller.trouParTick += e.modificateurTrousParClick;
                    TroueurGlobal.baseTrouIncrement += incrementUpgradeBrut;
                }
            }
        }}

    }

    public void reset()
    {

        if (this.applique)
        {

            this.applique = false;

            GameObject items = GameObject.Find("Items");

            foreach (Transform child in items.transform)
            {
                ItemController controller = child.GetComponent<ItemController>();
                foreach (effet e in effets)
                {
                    if (e.itemId == controller.id)
                    {
                        controller.trouParTick -= e.baseProdUpgrade;
                        controller.tickDelay /= e.speedModifier;
                        controller.trouParTick -= e.modificateurTrousParClick;
                        TroueurGlobal.baseTrouIncrement -= incrementUpgradeBrut;
                    }
                }
            }
        }

    }


}
