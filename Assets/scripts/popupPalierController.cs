using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popupPalierController : MonoBehaviour
{

    public List<Sprite> popups;


    private void Awake() {
        int palier;

        try
        {
            palier = transform.parent.GetComponent<ShopItemController>().item.GetComponent<ItemController>().unlockPalier;
        }
        catch
        {
            try
            {
                palier = transform.parent.GetComponent<shopUpgradeController>().upgrade.GetComponent<upgradeController>().unlockPalier;
            }
            catch
            {
                palier = PalierManager.palier;
            }
        }

        GetComponent<UnityEngine.UI.Image>().sprite = popups[palier - 1];
        GetComponent<UnityEngine.UI.Image>().color = Color.white;
    }

    // Start is called before the first frame update
    void Start()
    {
        int palier;

        

        try
        {
            palier = transform.parent.GetComponent<ShopItemController>().item.GetComponent<ItemController>().unlockPalier;
        }
        catch
        {
            try
            {
                palier = transform.parent.GetComponent<shopUpgradeController>().upgrade.GetComponent<upgradeController>().unlockPalier;
            }
            catch
            {
                palier = PalierManager.palier;
            }
        }

        GetComponent<UnityEngine.UI.Image>().sprite = popups[palier - 1];
    }

    private void OnEnable() {
        int palier;
        try
        {
            palier = transform.parent.GetComponent<ShopItemController>().item.GetComponent<ItemController>().unlockPalier;
        }
        catch
        {
            try
            {
                palier = transform.parent.GetComponent<shopUpgradeController>().upgrade.GetComponent<upgradeController>().unlockPalier;
            }
            catch
            {
                palier = PalierManager.palier;
            }
        }

        GetComponent<UnityEngine.UI.Image>().sprite = popups[palier - 1];
    }

    
}
