using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forceShake : MonoBehaviour
{

    private objectShake os;
    // Start is called before the first frame update
    void Start()
    {
        os = GetComponent<objectShake>();
        os.Shake();
    }

    // Update is called once per frame
    void Update()
    {
        os.Shake();
    }
}
