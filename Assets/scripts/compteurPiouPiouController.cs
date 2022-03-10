using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class compteurPiouPiouController : MonoBehaviour
{

    private TMPro.TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMPro.TextMeshProUGUI>();
        text.text = TroueurGlobal.nbClickPiouPiou.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
