using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noteController : MonoBehaviour
{

    UnityEngine.UI.Toggle ToggleMusique;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        ToggleMusique = GameObject.Find("ToggleMusique").GetComponent<UnityEngine.UI.Toggle>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("musiqueActive", ToggleMusique.isOn);
    }
}
