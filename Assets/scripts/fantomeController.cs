using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fantomeController : MonoBehaviour
{
    public Vector3 trBounds;
    public Vector3 blBounds;

    
    public float speed;

    public Vector3 chemin;

    private float starttime;

    public float freq = 1;
    public float ampl = 1;

    private void Start() {
        starttime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mvm = chemin.normalized;
        Vector3 ort = Vector2.Perpendicular(mvm);

        ort *= Mathf.Cos((Time.time - starttime) * freq) * ampl;

        mvm += ort;

        mvm *= Time.deltaTime * speed;


        transform.parent.position += mvm;


        if (transform.parent.localPosition.x < trBounds.x || transform.parent.localPosition.x > blBounds.x || transform.parent.localPosition.y > trBounds.y || transform.parent.localPosition.y < blBounds.y) {
            
            Destroy(this.transform.parent.gameObject);
        }
    }
}
