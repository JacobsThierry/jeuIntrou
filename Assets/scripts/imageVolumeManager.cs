using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class imageVolumeManager : MonoBehaviour
{

    public Sprite son0;
    public Sprite son33;
    public Sprite son66;
    public Sprite son100;
    public UnityEngine.UI.Image image;

    private soundManagerController soundManagerController;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<UnityEngine.UI.Image>();
        soundManagerController = GameObject.Find("soundManager").GetComponent<soundManagerController>();

    }

    // Update is called once per frame
    void Update()
    {
        //c'est quoi un tableau ? c'est quoi une boucle ?
        if (soundManagerController.volume <= 0) {
            image.sprite = son0;
        }else if (soundManagerController.volume <= 0.33) {
            image.sprite = son33;
        }else if (soundManagerController.volume <= 0.66){
            image.sprite = son66;
        }else {
            image.sprite = son100;
        }
    }
}
