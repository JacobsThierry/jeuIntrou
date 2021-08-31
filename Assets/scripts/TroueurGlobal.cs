using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroueurGlobal : MonoBehaviour
{

    

    public static long nbTrous = 0;
    public static long baseTrouIncrement = 1;
    public static long trouParSeconde = 0;

    public static long getIncrement()
    {
        long trous = baseTrouIncrement;
        GameObject items = GameObject.Find("Items");
        foreach (Transform child in items.transform)
        {
            ItemController controller = child.GetComponent<ItemController>();
            trous += controller.incrementTrousParClick * controller.quantite;

        }

        foreach (Transform upgrade in GameObject.Find("Upgrades").transform)
        {
            if(upgrade.GetComponent<upgradeController>().achete)
                trous += upgrade.GetComponent<upgradeController>().incrementUpgradeBrut;
        }

        return trous;
    }
}
