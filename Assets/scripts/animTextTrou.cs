using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animTextTrou : MonoBehaviour
{

    private Vector3 initialScale;
    public float maxScale;
    public float deltaScale;
    public float resetSpeed;

    public float resetsizeTimer;

    private float timer;

    public Gradient colorGradient;

    private TMPro.TextMeshProUGUI text;


    void onClick()
    {
        timer = resetsizeTimer;
        Vector3 v = new Vector3(transform.localScale.x + deltaScale, transform.localScale.y + deltaScale, transform.localScale.z + deltaScale);
        if (v.x < maxScale)
        {
            transform.localScale = v;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        initialScale = transform.localScale;
        text = GetComponent<TMPro.TextMeshProUGUI>();
        heatManager.click.AddListener(onClick);
    }

    // Update is called once per frame
    void Update()
    {

        if (timer > -1)
        {
            timer -= Time.deltaTime;
        }
        Debug.Log(timer);



        if (timer < 0 && transform.localScale.x > initialScale.x)
        {
            Vector3 v = (new Vector3(transform.localScale.x - resetSpeed * Time.deltaTime, transform.localScale.y - resetSpeed * Time.deltaTime, transform.localScale.z - resetSpeed * Time.deltaTime));
            Debug.Log(v.x);
            if (v.x < initialScale.x)
            {
                transform.localScale = initialScale;
            }
            else
            {
                transform.localScale = v;
            }
        }

        text.color = colorGradient.Evaluate(heatManager.getHeat01());
    }
}
