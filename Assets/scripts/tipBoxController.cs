using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tipBoxController : MonoBehaviour
{




    public TextAsset messages;

    public GameObject text;
    GameObject child;


    public void reallyCreateChild() {
        child = Instantiate(text, new Vector3(transform.localPosition.x, (GetComponent<RectTransform>().rect.width * 1.3f), transform.localPosition.z), Quaternion.identity, transform);
        child.transform.position = new Vector3(transform.position.x + GetComponent<RectTransform>().rect.width * 1.3f, transform.position.y, transform.position.z);
        child.GetComponent<TMPro.TextMeshProUGUI>().text = getLine();
    }

    public void createChild() {

        Debug.Log(transform.childCount);

        if (transform.childCount < 2) {
            reallyCreateChild();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        reallyCreateChild();
    }


    string getLine()
    {

        string[] dataLines = messages.text.Split('\n');


        int currentLine = Random.Range(0, dataLines.Length);

        return dataLines[currentLine] + '\t';

    }

    private int idFingerMoving = -1;
    private Vector3 oldFinger;
    


    // Update is called once per frame
    void Update()
    {
        if (transform.childCount == 0) {
            reallyCreateChild();
        }


        Rect hitbox = GetComponent<RectTransform>().rect;


        foreach (Touch touch in Input.touches)
        {
            int id = touch.fingerId;           

            Debug.Log("id = " + id + " id moved : " + idFingerMoving + " delta = " + touch.deltaPosition + " position = " + touch.position + " local pos parent = " + transform.parent.InverseTransformPoint(touch.position) + " local pos tip :" + transform.InverseTransformPoint(touch.position)  + " rect pos = " + hitbox.position );

            if (hitbox.Contains( transform.InverseTransformPoint(touch.position)) && touch.phase == TouchPhase.Began)
            {
                idFingerMoving = id;
            }

            if (id == idFingerMoving) {
                
                if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                {
                    idFingerMoving = -1;
                }
                
                foreach (Transform child in transform) {
                    child.position += new Vector3(touch.deltaPosition.x, 0, 0);
                }
            }

            

        }
    }
}
