using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompteurPiegesController : MonoBehaviour
{


    private TMPro.TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMPro.TextMeshProUGUI>();
        text.text = TroueurGlobal.nbClickPiege.ToString();

    }

    // Update is called once per frame
    void Update()
    {

    }

}
