using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boutonExit2 : MonoBehaviour
{
    public void onClick()
    {
        GameObject.Find("soundManager").GetComponent<soundManagerController>().playSelect();
        Destroy(transform.parent.parent.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
