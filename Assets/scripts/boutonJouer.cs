using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class boutonJouer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void onClick() {
        GameObject.Find("soundManager").GetComponent<soundManagerController>().playSelect();
        SceneManager.LoadScene("GameScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
