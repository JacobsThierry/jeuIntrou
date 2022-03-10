using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemListController : MonoBehaviour
{

    public GameObject shopItem;

    // Start is called before the first frame update
    void Start()
    {
        GameObject items = GameObject.Find("Items");
        foreach (Transform child in items.transform) {
            ItemController ic = child.GetComponent<ItemController>();
            if (ic.unlockPalier <= PalierManager.palier) { 
                GameObject si = Instantiate(shopItem, new Vector3(0, 0, 0), Quaternion.identity, transform);
                si.GetComponent<ShopItemController>().item = child.gameObject;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
