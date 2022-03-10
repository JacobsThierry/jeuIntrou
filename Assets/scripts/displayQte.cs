using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class displayQte : MonoBehaviour
{

    public GameObject textQte;
    public float rota = 3;
    

    // Start is called before the first frame update
    void Start()
    {
        //heatManager.click.AddListener(delegate { displayPlus(TroueurGlobal.getIncrement()); });
        ItemController.itemEvent.AddListener(displayPlus);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void displayPlus(long qte)
    {
        GameObject a = Instantiate(textQte, transform.GetChild(0));
        
        Quaternion originRotation = a.transform.rotation;
        a.transform.rotation = Quaternion.Euler(0, 0, Random.Range(-rota, +rota));
        a.transform.localPosition = Vector3.zero;
        a.transform.position += new Vector3(Random.Range(-GetComponent<RectTransform>().rect.width * 0.35f, GetComponent<RectTransform>().rect.width * 0.35f), Random.Range(-GetComponent<RectTransform>().rect.height/2, GetComponent<RectTransform>().rect.height/2), 0);
        a.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = "+" + TroueurGlobal.formatString(qte);
    }
}
