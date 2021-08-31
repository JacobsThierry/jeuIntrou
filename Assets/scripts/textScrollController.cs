using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textScrollController : MonoBehaviour
{

    public float speed;

    private bool spawn = false;

    private void Awake() {
        
        

    }


    

    // Update is called once per frame
    void Update()
    {
        float lim = transform.parent.position.x - transform.parent.GetComponent<RectTransform>().rect.width * 2 - GetComponent<RectTransform>().rect.width * 2;
        //Debug.Log("poof = " + lim + " cur = " + transform.position.x.ToString());
        if (transform.position.x < lim *1.1 ) {
            Destroy(this.gameObject, 2f);
        }else if (!spawn && transform.position.x < lim) {
            spawn = true;
            transform.parent.GetComponent<tipBoxController>().reallyCreateChild();
        }

        transform.position = new Vector3(transform.position.x - speed * 20 * Time.deltaTime, transform.position.y, transform.position.z);

    }

    private void OnDestroy() {
        
    }
}
