using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animTitre : MonoBehaviour
{

    public Gradient gradient;
    public float gradSpeed = 1f;

    private TMPro.TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        text.color = gradient.Evaluate((Time.time * gradSpeed) % 1);
    }
}
