using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontdestroyonload : MonoBehaviour
{

    public static GameObject dontDestroyOnLoad;

    void Awake()
        {

        int i = 0;

        foreach (var gameObj in FindObjectsOfType(typeof(GameObject)) as GameObject[])
        {
            if (gameObj.name == this.gameObject.name)
            {
                i++;
                if (i > 1) {
                    Destroy(this.gameObject);
                }
            }
        }
        
        DontDestroyOnLoad(this);
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        dontDestroyOnLoad = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
