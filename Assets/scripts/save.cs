using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CI.QuickSave;

public class save : MonoBehaviour
{

    public float autoSaveFreq = 30f;
    // Start is called before the first frame update
    void Start()
    {
        loadAll();
        StartCoroutine("autoSave");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnApplicationQuit() {
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


        writer.Write<float>("volume", GameObject.Find("soundManager").GetComponent<soundManagerController>().volume);


        writer.Write<long>("Trous", TroueurGlobal.nbTrous);
        var items = transform.Find("Items");
        foreach(Transform item in items) {
            writer.Write<long>("Item" + item.GetComponent<ItemController>().transform.GetSiblingIndex().ToString(), item.GetComponent<ItemController>().quantite);
        }

        var upgrades = transform.Find("Upgrades");
        foreach (Transform upgrade in upgrades) {
            var up = upgrade.GetComponent<upgradeController>();
            writer.Write<bool>("Upgrade" + up.transform.GetSiblingIndex().ToString(), up.achete);
        }
        writer.Commit();
        Debug.Log("Saved");

    }

    public void resetAll() {
        var writer = QuickSaveWriter.Create("Player", new QuickSaveSettings()
        {
            SecurityMode = SecurityMode.Aes,
            Password = "WowLeMotDePasseIncroyableSiLongQuIlNePeuPas3treCrackerJenSuisSurBonjourValekoz",
            CompressionMode = CompressionMode.Gzip
        });
        writer.Write<long>("Trous", 0);
        var items = transform.Find("Items");
        foreach (Transform item in items)
        {
            writer.Write<long>("Item" + item.GetComponent<ItemController>().transform.GetSiblingIndex().ToString(), 0);
        }

        var upgrades = transform.Find("Upgrades");
        foreach (Transform upgrade in upgrades)
        {
            var up = upgrade.GetComponent<upgradeController>();
            up.reset();
            writer.Write<bool>("Upgrade" + up.transform.GetSiblingIndex().ToString(), false);

        }
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
            Debug.Log("Reseted");
        }catch (QuickSaveException) {
            ;
        }

    }
}
