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
        Debug.Log("editor");
        foreach (Transform child in transform) {
            try { 
            child.gameObject.GetComponent<ItemController>().id = child.GetSiblingIndex();
           //     SortChildrenItem(transform);
            }catch {
                try
                {
                    child.gameObject.GetComponent<upgradeController>().id = child.GetSiblingIndex();
             //       SortChildrenUpgrade(transform);

                }
                catch {; }
            }
            }
    }


    public static void SortChildrenItem(Transform a)
    {
        Debug.Log("sort");
        List<Transform> children = new List<Transform>();
        foreach (Transform b in a)
        {
            Debug.Log("aaa = " + b.GetComponent<upgradeController>().name);
            GameObject obj = b.gameObject;

            children.Add(b);

            //    b.parent = null;




        }
        children.Sort((Transform t1, Transform t2) => { return t1.GetComponent<ItemController>().prix.BigInteger.CompareTo(t2.GetComponent<ItemController>().prix.BigInteger); });

        for (int i = 0; i < children.Count; i++)
        {
            Transform child = children[i];
            Debug.Log("bbb = " + child.GetComponent<ItemController>().name);
            child.parent = a;
            child.SetSiblingIndex(i);
        }



    }

    public static void SortChildrenUpgrade(Transform a)
    {
        Debug.Log("sort");
        List<Transform> children = new List<Transform>();
        foreach (Transform b in a)
        {
            Debug.Log("aaa = " + b.GetComponent<upgradeController>().name);
            GameObject obj = b.gameObject;
            
            children.Add(b);

        //    b.parent = null;




        }
        children.Sort((Transform t1, Transform t2) => { return t1.GetComponent<upgradeController>().prix.BigInteger.CompareTo(t2.GetComponent<upgradeController>().prix.BigInteger); });
        
                for (int i = 0; i < children.Count;i++)
                {
                    Transform child = children[i];
                    Debug.Log("bbb = " + child.GetComponent<upgradeController>().name);
                    child.parent = a;
            child.SetSiblingIndex(i);
        }

        

    } 
}
