using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popupPromptController : MonoBehaviour
{

    public GameObject goSiOui;
    public GameObject goSiNon;

    public string text;

    private void Start() {
        transform.Find("textPrompt").GetComponent<TMPro.TextMeshProUGUI>().text = text;
    }


    public void onClickOui() {
        GameObject.Find("soundManager").GetComponent<soundManagerController>().playSelect();
        if (goSiOui != null)
            Instantiate(goSiOui, transform.parent);
        Destroy(this.gameObject);
    }

    public void onClickNon()
    {
        GameObject.Find("soundManager").GetComponent<soundManagerController>().playHit();
        if(goSiNon != null)
            Instantiate(goSiNon, transform.parent);
        Destroy(this.gameObject);
    }

}
