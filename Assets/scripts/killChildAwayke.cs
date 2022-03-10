using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killChildAwayke : MonoBehaviour
{
  
  

    private void OnEnable() {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
