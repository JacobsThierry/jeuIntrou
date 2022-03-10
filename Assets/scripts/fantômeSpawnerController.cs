using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fantômeSpawnerController : pioupiouSpawner
{

    public Vector2 targetDelta;
    public Vector2 deltaAmp;
    public Vector2 deltaFrq;

    public Vector2 trBound;
    public Vector2 blBound;



    public override void spawn() {
        Debug.Log("boooooooo");
        Vector3 pos = ((Random.insideUnitCircle).normalized)* piouPiouRange.x;
        
        GameObject p = Instantiate(pioupiou, Vector3.zero, Quaternion.identity, transform);
        fantomeController fc = p.transform.GetChild(0).GetComponent<fantomeController>();
        fc.trBounds = trBound;
        fc.blBounds = blBound;
        p.transform.SetParent(transform);

        p.transform.localScale = Vector3.one;
        p.transform.localPosition = pos;

        Vector3 targetDir = GetComponent<RectTransform>().position - p.transform.position + new Vector3(Random.Range(-targetDelta.x, targetDelta.x), Random.Range(-targetDelta.y, targetDelta.y), 0);

        
        

        fc.chemin = targetDir;
        fc.ampl = Random.Range(deltaAmp.x, deltaAmp.y);
        fc.freq = Random.Range(deltaFrq.x, deltaFrq.y);





    }
}
