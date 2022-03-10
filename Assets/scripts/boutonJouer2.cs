using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boutonJouer2 : MonoBehaviour
{


    public void onClick(){
        GameObject.Find("CanvasManager").GetComponent<CanvasManager>().activerCanvasJeu();
    }

}
