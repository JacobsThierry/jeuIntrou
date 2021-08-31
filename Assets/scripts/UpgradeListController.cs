using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeListController : MonoBehaviour
{

    public GameObject shopUpgrade;

    // Start is called before the first frame update
    void Start()
    {
        GameObject items = GameObject.Find("Upgrades");
        foreach (Transform child in items.transform)
        {
            if (!child.gameObject.GetComponent<upgradeController>().cache || child.gameObject.GetComponent<upgradeController>().achete) { 
            GameObject si = Instantiate(shopUpgrade, new Vector3(0, 0, 0), Quaternion.identity, transform);
            si.GetComponent<shopUpgradeController>().upgrade = child.gameObject;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
