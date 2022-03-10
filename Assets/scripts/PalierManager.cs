using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Numerics;

public class PalierManager : MonoBehaviour
{

    public static UnityEngine.Events.UnityEvent<int> palierChanger = new UnityEngine.Events.UnityEvent<int>();


    [System.Serializable]
    public class Palier {
        [TextArea(15, 20)]
        public string nom;
        [TextArea(15, 20)]
        public string desc;

        [SerializeField]
        public SerializableBigInteger prix;
    }

    [SerializeField]
    public List<Palier> paliers;

    private static int _palier = 1;
    private static PalierManager instance;




    public static int palier{
        get {
            palierChanger.Invoke(_palier);
            return _palier; }
        set {
            Debug.Log("ChangerLePalier");
            palierChanger.Invoke(value);
            instance.endScene(value);

            GameObject bg = GameObject.Find("Rainpos").transform.parent.gameObject;
            if (bg != null) {
                Debug.Log("changer je pete un cable");
                bg.GetComponent<BackgroundPalierManager>().changerBG(value);
            }
            
            _palier = value;
            save.instance.saveAll();

        }
    }


    private void Start() {
        instance = this;
        endScene(palier);
    }


    private void OnEnable() {
        instance = this;
    }

    private void Awake() {
        instance = this;
    }


    void endScene(int v) {
        if (v > 3)
        {
            Debug.Log("soo");
            soundManagerController.instance.musiqueOn = false;

            SceneManager.LoadScene("endScene");
        }
    }


}
