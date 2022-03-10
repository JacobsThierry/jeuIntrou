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

    public SerializableBigInteger prix;

    public long incrementUpgradeBrut;
    public int unlockPalier = 1;

    


    [System.Serializable]
    public class effet {
        public GameObject item;
        public long baseProdUpgrade;
        public SerializableBigInteger modificateurTrousParClick;
        public float speedModifier=1;
    }

    public Sprite image;

    public List<effet> effets;

    
    public bool achete{
        get {return _achete; }
        set {
            if (value && !_achete) {
                appliquer();
            }else if (!value && achete) {
                reset();
            }

            _achete = value;
        }
    }

    [SerializeField]
    private bool _achete;

    public bool cache = false;
    

    private bool applique{
        get { return _applique; }
        set {
            
            if(value){
                appliquer();
            }else {
                reset();
            }
        }
    }


    private bool _applique = false;


private void Start() {
        
    }

    public void appliquer() {

        if (!this.applique) { 

        this._applique = true;
            Debug.Log("pppp = " + this.nom);
            TroueurGlobal.baseTrouIncrement += incrementUpgradeBrut;
            foreach (effet e in effets) {

                
                    ItemController controller = e.item.GetComponent<ItemController>();
                    controller.trouParTick.BigInteger += e.baseProdUpgrade;
                    controller.tickDelay *= e.speedModifier;
                //controller.trouParTick += e.modificateurTrousParClick;
                controller.incrementTrousParClick.BigInteger += e.modificateurTrousParClick;
                
                
                
            }
        }

    }

    public void reset()
    {

        if (this.applique)
        {

            this._applique = false;

            GameObject items = GameObject.Find("Items");


            TroueurGlobal.baseTrouIncrement -= incrementUpgradeBrut;

            foreach (effet e in effets)
                {
                ItemController controller = e.item.GetComponent<ItemController>();
                    
                        controller.trouParTick.BigInteger -= e.baseProdUpgrade;
                        controller.tickDelay /= e.speedModifier;
                        //controller.trouParTick -= e.modificateurTrousParClick;
                        TroueurGlobal.baseTrouIncrement -= incrementUpgradeBrut;
                Debug.Log("increment avant : " + controller.incrementTrousParClick);
                controller.incrementTrousParClick.BigInteger -= e.modificateurTrousParClick;
                Debug.Log("increment après : " + controller.incrementTrousParClick);
                    
                }
            }
        }

    


}
