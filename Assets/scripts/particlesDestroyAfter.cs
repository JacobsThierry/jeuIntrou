using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particlesDestroyAfter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float timer = this.GetComponent<UIParticleSystem>().Duration + this.GetComponent<UIParticleSystem>().Lifetime + 0.2f;
        Destroy(gameObject, timer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
