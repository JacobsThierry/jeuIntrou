using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fixScale : MonoBehaviour
{

    public Vector3 scale;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = scale;
    }
}
