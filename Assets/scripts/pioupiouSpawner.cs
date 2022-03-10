using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pioupiouSpawner : MonoBehaviour
{

    public GameObject pioupiou;
    public float pioupiouTimer = 35f;
    private float timer;
    public int palier;


    public Vector2 piouPiouRange;

    private void Start() {
        timer = pioupiouTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (palier <= PalierManager.palier) { 

        timer -= Time.deltaTime;

        if (timer - heatManager.getHeat() <= 0) {
            timer = pioupiouTimer;
            if(Random.Range(0,1) < heatManager.getHeat01()/1.06f + 0.05f || true){
                    spawn();
                }
        }
    }}


    public virtual void spawn() {
        GameObject p = Instantiate(pioupiou);
        p.transform.parent = this.transform;
        p.GetComponent<RectTransform>().localPosition = new Vector3(0, Random.Range(piouPiouRange.x, piouPiouRange.y), 0);
        p.GetComponent<RectTransform>().localScale = Vector3.one;
    }
}
