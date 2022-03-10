using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorScroll : MonoBehaviour
{

    public float speed;
    public Gradient gradient;
    private float state;
    private TMPro.TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        state = 0;
        text = GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        state = state > 1f ? 0 : (state + speed * Time.deltaTime);
        text.color = gradient.Evaluate(state);
    }
}
