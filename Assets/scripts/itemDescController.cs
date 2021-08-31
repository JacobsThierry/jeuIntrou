using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemDescController : MonoBehaviour
{

    public GameObject item;
    public RectTransform panelRectTransform;

    // Start is called before the first frame update
    void Start()
    {
        transform.Find("popup/Content/Content/nomItem").GetComponent<TMPro.TextMeshProUGUI>().text = item.GetComponent<ItemController>().nom;
        transform.Find("popup/Content/Content/descItem").GetComponent<TMPro.TextMeshProUGUI>().text = item.GetComponent<ItemController>().description;        
    }

    public void onClick() {
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
