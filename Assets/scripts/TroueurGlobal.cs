using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;
using System.Numerics;

public class TroueurGlobal : MonoBehaviour
{



    private static BigInteger _nbTrous = 0;

    public static BigInteger nbTrous{
        get {return _nbTrous; }
        set {
            if (value > _nbTrous)
            {
                trousTotalProduit += value - _nbTrous;
            }

            if (value >= 0) { 
            _nbTrous = value;
            }else {
                _nbTrous = 0;
            }

        }

    }


    public static string formatString(BigInteger l) {
        string TrousPre = l.ToString("N", CultureInfo.CreateSpecificCulture("fr-CA"));
        return TrousPre.Split(',')[0];
    }

    public static string getNbTrous() {
        return formatString(nbTrous);
    }

    public static double tempsDeJeu = 0f;

    public static long baseTrouIncrement = 1;
    public static long nbclic;
    public static BigInteger trousTotalProduit=0;

    public static long nbClickPiouPiou = 0;
    public static long nbClickPiege = 0;

    private void Update() {
        //nbTrous += 999999999;
        tempsDeJeu += Time.deltaTime;
    }

    public static long getTrousParSeconde() {
        GameObject i = GameObject.Find("Items");
        long a = 0;
        foreach (Transform item in i.transform) {
            ItemController ic = item.GetComponent<ItemController>();
            a += (long) (ic.quantite * (ic.trouParTick / ic.tickDelay));

        }

        Debug.Log("Trous par seconde = " + a);

        return a;
    }

    

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

        return trous * (long) (heatManager.plancheFois2()?2f:1f);
    }
}
