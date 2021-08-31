using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ClickEffetTrou : MonoBehaviour
{
    public List<GameObject> ParticuleTrou;
    public float quantiteParticleTrous = 1;


    void click()
    {

        Vector3 mousePos;
        if (Input.touchCount > 0)
        {
            mousePos = Input.GetTouch(Input.touchCount - 1).position;
        }
        else
        {
            mousePos = Input.mousePosition;
        }

        if ((quantiteParticleTrous * 30) / ParticuleTrou.Count > 0)
        {

            foreach (GameObject trou in ParticuleTrou)
            {

                GameObject t = Instantiate(trou, mousePos, Quaternion.identity);
                UIParticleSystem uips = t.GetComponent<UIParticleSystem>();
                uips.EmissionsPerSecond = (quantiteParticleTrous * 30) / ParticuleTrou.Count;
                t.transform.parent = GameObject.Find("CanvasParticles").transform;
            }
        }
    }


private void Start() {
        heatManager.click.AddListener(click);
    }

    public void onClick() {

        heatManager.click.Invoke();


}



}
