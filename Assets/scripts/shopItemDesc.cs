using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopItemDesc : MonoBehaviour
{

    public GameObject popup;

    public void onClick() {
        GameObject pop = Instantiate(popup, transform.parent.parent.parent.parent);
        pop.GetComponent<itemDescController>().item = transform.parent.parent.gameObject.GetComponent<ShopItemController>().item;
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
