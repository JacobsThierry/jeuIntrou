using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuickPool;

public class ClickEffetTrou : MonoBehaviour
{
    public float quantiteParticleTrous = 1;

    private Transform canvasParticules;


    public Pool pool1 = new Pool()
    {
        size = 100,
        allowGrowth = true
    };

    public Pool pool2 = new Pool()
    {
        size = 100,
        allowGrowth = true
    };

    

    void click()
    {
        if (10f / pool1.spawnedCount >= Random.Range(0f, 1f)) { 
        Vector3 mousePos;
        if (Input.touchCount > 0)
        {
            mousePos = Input.GetTouch(Input.touchCount - 1).position;
        }
        else
        {
            mousePos = Input.mousePosition;
        }

        //if ((quantiteParticleTrous * 30) / ParticuleTrou.Count > 0)
        //{

        //foreach (GameObject trou in ParticuleTrou)
        /*foreach (Pool item in LP)
        {*/

        //GameObject t = Instantiate(trou, mousePos, Quaternion.identity);


        

        GameObject t = pool1.Spawn(mousePos, Quaternion.identity);
        float q = Random.Range(0, (quantiteParticleTrous * 30) / (2 + pool1.spawnedCount));
        float r = q;



        Debug.Log("clock");
            UIParticleSystem uips = t.GetComponent<UIParticleSystem>();

        if (q < 1 / uips.Duration) {
            float rr = Random.Range(0f,1f);
            Debug.Log("rr = " + rr);
            if  (rr >= 0.5f) { 

            q = 1 / uips.Duration;
            r = 0;
            }else {
                q = 0;
                r = 1 / uips.Duration;
            }
        }



        uips.EmissionsPerSecond = q;
        t.transform.SetParent(canvasParticules, true);

            

        StartCoroutine(delayedStart(uips));
        StartCoroutine(despawnAfter(uips));

        if (r > 0) { 
        t = pool2.Spawn(mousePos, Quaternion.identity);

            Debug.Log("clock");
            uips = t.GetComponent<UIParticleSystem>();
            uips.EmissionsPerSecond = r;
            t.transform.SetParent(canvasParticules, true);
            StartCoroutine(delayedStart(uips));
            StartCoroutine(despawnAfter(uips));
            //}
        }
       // }
    }}

private IEnumerator despawnAfter(UIParticleSystem uips){
        yield return new WaitForSeconds(uips.Lifetime + uips.Duration + 0.05f);
        uips.gameObject.Despawn();
    }

    private IEnumerator delayedStart(UIParticleSystem uips) {

        foreach (Transform chil in uips.transform) {
            chil.gameObject.SetActive(false);
        }

        yield return null;
        yield return null;
        uips.Play();
    }


    private void Start() {
        Debug.Log("aaaaa");
        pool1.Initialize();
        pool2.Initialize();
        PoolsManager.RegisterPool(pool1); //register pool if you want to use extention method Despawn
        PoolsManager.RegisterPool(pool2); //register pool if you want to use extention method Despawn
        heatManager.click.AddListener(click);
        canvasParticules = GameObject.Find("CanvasParticles").transform;
    }

    public void onClick() {

        heatManager.click.Invoke();


}



}
