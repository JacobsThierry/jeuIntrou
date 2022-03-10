using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoutonValiderCode : MonoBehaviour
{

    public TMPro.TMP_InputField field;
    public TextAsset codes;

    public GameObject popup;

    public void onClick() {
        string[] dataLines = codes.text.Split('\n');

        Debug.Log("Code entrer = " + field.text);

        foreach (string code in dataLines) {

            
            string pswd = code.Split(';')[1];
            Debug.Log("code check = " + pswd);
            Debug.Log("code bon = " + field.text.Trim().Equals(pswd.Trim()));

            if (field.text.Trim().Equals(pswd.Trim())) {
                int id = int.Parse(code.Split(';')[0]);
                Debug.Log("OUI");

                upgradeController up = new upgradeController();

                foreach (Transform child in GameObject.Find("items and upgrades").transform.Find("Upgrades")) {
                    if (child.GetComponent<upgradeController>().id == id) {
                        up = child.GetComponent<upgradeController>();
                    }
                }

                GameObject p =  Instantiate(popup, transform.parent);
                p.GetComponent<upgradeUnlockPopupController>().item = up.gameObject;

                StartCoroutine(nextFrame(up));

                return;




            }

            
        }

        soundManagerController.instance.playBuy();


    }


    private IEnumerator nextFrame(upgradeController u) {
        yield return null;
        u.achete = true;
    }

}
