using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject popupPrompt;
    public GameObject reset;

    public void onClick() {
        GameObject.Find("soundManager").GetComponent<soundManagerController>().playHit();
        GameObject prompt = Instantiate(popupPrompt, transform.parent);
        prompt.GetComponent<popupPromptController>().text = "Veut tu vraiment supprimer ta progression ?";
        prompt.GetComponent<popupPromptController>().goSiOui = reset;


    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
