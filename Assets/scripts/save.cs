using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CI.QuickSave;
using System.Numerics;


public class save : MonoBehaviour
{


    public static save instance;
    public float autoSaveFreq = 30f;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        loadAll();
        StartCoroutine("autoSave");
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    bool isPaused = false;


    void OnApplicationFocus(bool hasFocus)
    {

        Debug.Log("SaveFocus " + hasFocus + " savePause : " + isPaused);

        if (isPaused && hasFocus) {
            loadAll();
            saveAll();
        }

        if (hasFocus) {
            isPaused = false;
        }

    }


    /// <summary>
    /// Callback sent to all game objects when the player pauses.
    /// </summary>
    /// <param name="pauseStatus">The pause state of the application.</param>
    void OnApplicationPause(bool pauseStatus)
    {
        isPaused = pauseStatus;
        Debug.Log(" SavePause : " + isPaused);
        
        saveAll();
    }

    

    private IEnumerator autoSave() {
        while (true) {
            saveAll();
            yield return new WaitForSeconds(autoSaveFreq);
        }
    }

    public void saveAll() {
        

        var writer = QuickSaveWriter.Create("Player", new QuickSaveSettings()
        {
            SecurityMode = SecurityMode.Aes,
            Password = "WowLeMotDePasseIncroyableSiLongQuIlNePeuPas3treCrackerJenSuisSurBonjourValekoz",
            CompressionMode = CompressionMode.Gzip
        });

        writer.Write<long>("NbClickPiouPiou", TroueurGlobal.nbClickPiouPiou);

        writer.Write<int>("palier", PalierManager.palier);
        writer.Write<long>("nbClick", TroueurGlobal.nbclic);

        writer.Write<BigInteger>("TotalProduit", TroueurGlobal.trousTotalProduit);

        writer.Write<double>("TempsTotal", TroueurGlobal.tempsDeJeu);

        writer.Write<float>("volume", GameObject.Find("soundManager").GetComponent<soundManagerController>().volume);
        writer.Write<bool>("musique", GameObject.Find("soundManager").GetComponent<soundManagerController>().musiqueOn);


        writer.Write<BigInteger>("Trous", TroueurGlobal.nbTrous);
        var items = transform.Find("Items");
        foreach(Transform item in items) {
            writer.Write<long>("Item" + item.GetComponent<ItemController>().transform.GetSiblingIndex().ToString(), item.GetComponent<ItemController>().quantite);
        }

        var upgrades = transform.Find("Upgrades");
        foreach (Transform upgrade in upgrades) {
            var up = upgrade.GetComponent<upgradeController>();
            writer.Write<bool>("Upgrade" + up.transform.GetSiblingIndex().ToString(), up.achete);
            
        }

        writer.Write<double>("time", getTime() );


        writer.Commit();
        Debug.Log("Saved");

    }

    public double getTime() {
        return System.DateTime.UtcNow.Subtract(new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc)).TotalSeconds;
    }

    public void resetAll() {
        var writer = QuickSaveWriter.Create("Player", new QuickSaveSettings()
        {
            SecurityMode = SecurityMode.Aes,
            Password = "WowLeMotDePasseIncroyableSiLongQuIlNePeuPas3treCrackerJenSuisSurBonjourValekoz",
            CompressionMode = CompressionMode.Gzip
        });
        writer.Write<long>("Trous", 0);
        writer.Write<long>("nbClick", 0);
        writer.Write<BigInteger>("TotalProduit", 0);
        var items = transform.Find("Items");
        foreach (Transform item in items)
        {
            writer.Write<long>("Item" + item.GetComponent<ItemController>().transform.GetSiblingIndex().ToString(), 0);
        }

        writer.Write<double>("TempsTotal", 0);

        writer.Write<long>("NbClickPiouPiou", 0);

        var upgrades = transform.Find("Upgrades");
        foreach (Transform upgrade in upgrades)
        {
            var up = upgrade.GetComponent<upgradeController>();
            up.reset();
            writer.Write<bool>("Upgrade" + up.transform.GetSiblingIndex().ToString(), false);
            

        }
        writer.Write<double>("time", getTime());
        writer.Write<int>("palier", 1);




        rainController.instance.resetMax();
        writer.Commit();
        loadAll();
        
        
        Debug.Log("reset");
    }

    public void loadAll() {


        
        
        try { 
        var reader = QuickSaveReader.Create("Player", new QuickSaveSettings()
        {
            SecurityMode = SecurityMode.Aes,
            Password = "WowLeMotDePasseIncroyableSiLongQuIlNePeuPas3treCrackerJenSuisSurBonjourValekoz",
            CompressionMode = CompressionMode.Gzip
        });
        TroueurGlobal.nbTrous = reader.Read<long>("Trous");
        var items = transform.Find("Items");

            TroueurGlobal.nbclic = reader.Read<long>("nbClick");
            TroueurGlobal.trousTotalProduit = reader.Read<BigInteger>("TotalProduit");
            TroueurGlobal.nbClickPiouPiou = reader.Read<long>("NbClickPiouPiou");

            PalierManager.palier = reader.Read<int>("palier");

            TroueurGlobal.tempsDeJeu = reader.Read<double>("TempsTotal");

            foreach (Transform item in items)
        {
            var it = item.GetComponent<ItemController>();
            try {
                    it.quantite = reader.Read<long>("Item" + it.transform.GetSiblingIndex().ToString());
            }catch (QuickSaveException)
                {  
                    ;
                }
        }

        try
        {
                GameObject.Find("soundManager").GetComponent<soundManagerController>().volume = reader.Read<float>("volume");
                GameObject.Find("soundManager").GetComponent<soundManagerController>().musiqueOn = reader.Read<bool>("musique");
            }
        catch (QuickSaveException)
        {
                ;
            }

        var upgrades = transform.Find("Upgrades");
        foreach (Transform upgrade in upgrades)
        {
            var up = upgrade.GetComponent<upgradeController>();
            try { 
            up.achete = reader.Read<bool>("Upgrade" + up.transform.GetSiblingIndex().ToString());
            
            if (up.achete) {
                up.appliquer();
            }
                    
            }catch (QuickSaveException)
                {
                    ;
                }
        }

            
            double oldTime = reader.Read<double>("time");
            
            long delta = (long)(TroueurGlobal.getTrousParSeconde() * (getTime() - oldTime));
            Debug.Log("Delta = " + delta);
            Debug.Log("Old time = " + oldTime + " new time = " + getTime());
            if (delta < 0) {
                delta = 0;
            }
            TroueurGlobal.nbTrous += delta;



            Debug.Log("Loaded");
        }catch (QuickSaveException) {
            ;
        }

        

    }
}
