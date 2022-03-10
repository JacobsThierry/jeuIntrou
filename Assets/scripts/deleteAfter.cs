using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteAfter : MonoBehaviour
{

    public float time;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(destroyAfter(time));
    }


    private IEnumerator destroyAfter(float i) {
        yield return new WaitForSeconds(i);
        Destroy(this.gameObject);
    }

    private void OnDisable() {
        Destroy(this.gameObject);
    }
}
