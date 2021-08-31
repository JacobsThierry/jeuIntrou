using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class countChilds : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Transform child in transform) {
            try { 
            child.gameObject.GetComponent<ItemController>().id = child.GetSiblingIndex();
            }catch {
                try
                {
                    child.gameObject.GetComponent<upgradeController>().id = child.GetSiblingIndex();
                    { }
                }
                catch {; }
            }
            }
    }
}
