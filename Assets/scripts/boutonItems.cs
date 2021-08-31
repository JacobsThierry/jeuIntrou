using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boutonItems : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GameObject shopItems;

    public void onClick(){
        GameObject si = Instantiate(shopItems, transform.parent.parent);
        GameObject.Find("soundManager").GetComponent<soundManagerController>().playSelect();
        Destroy(transform.parent.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
