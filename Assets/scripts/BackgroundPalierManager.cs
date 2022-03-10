using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundPalierManager : MonoBehaviour
{

    public List<palierBG> foretPalier;
    public UnityEngine.UI.Image bg;
    

    public int palier;

    


    [System.Serializable]
    public class palierBG {
        public Sprite sprite;
        public Gradient filter;
        public Gradient background;
        public float gradSpeed;
    }

    // Start is called before the first frame update
    void Start()
    {
        
        bg = GetComponent<UnityEngine.UI.Image>();
        //bg.sprite = foret_verte;
        
        palier = PalierManager.palier;
        changerBG(palier);
        PalierManager.palierChanger.AddListener(changerBG);

    }


    private void Awake() {
        GameObject mp = GameObject.Find("items and upgrades");
        
        if (mp != null) {
            PalierManager pm = mp.GetComponent<PalierManager>();
            palier = PalierManager.palier;
            changerBG(palier);
        }
    }


    public void changerBG(int palierr){
        Debug.Log("changerBG");
        this.palier = palierr;
        bg.sprite = foretPalier[palier - 1].sprite;
        bg.color = foretPalier[palier - 1].filter.Evaluate(Mathf.Abs(Mathf.Cos(Time.time * foretPalier[palier - 1].gradSpeed)));
        
            Camera.main.backgroundColor = foretPalier[palier-1].background.Evaluate(Mathf.Abs(Mathf.Cos(Time.time * foretPalier[palier - 1].gradSpeed)));
            
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        bg.color = foretPalier[palier - 1].filter.Evaluate(Mathf.Abs(Mathf.Cos(Time.time * foretPalier[palier - 1].gradSpeed)));
        Camera.main.backgroundColor = foretPalier[palier-1].background.Evaluate(Mathf.Abs(Mathf.Cos(Time.time * foretPalier[palier - 1].gradSpeed)));
        
    }
}
