using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemController : MonoBehaviour
{



    public long id;
    public long quantite = 0;
    public long trouParTick;
    public float tickDelay;
    public long prix;
    public float coefficient;

    public long incrementTrousParClick;

    public string nom;

    [TextArea(15, 20)]
    public string description;

    public Sprite image;

    
 public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
rain = GameObject.Find("Rainpos").GetComponent<rainController>();
    }

    public float getPrix() {
        if (quantite == 0) return prix;
        return prix * quantite * coefficient;
    }


    private long get_prix_for_qte(long qte) {
        if(qte == 0) return prix;
        long a = (long) (prix * qte * coefficient);
        return a;
    }


    public long get_prix(long qte)
    {
        long somme = 0;
        for (long i = 0; i < qte; i++) {
            somme += get_prix_for_qte(quantite + i);
        }

        return somme;
    }

    public IEnumerator prod() {
        yield return new WaitForSeconds(tickDelay);

        while (true) {
            TroueurGlobal.nbTrous += trouParTick*quantite;
            if(trouParTick * quantite > 0)
                rain.makeRain(image, trouParTick*quantite);

            yield return new WaitForSeconds(tickDelay);

        }

        
    }

    private rainController rain;

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        StartCoroutine("prod");
    }

     private void Awake() {
        rain = GameObject.Find("Rainpos").GetComponent<rainController>();
        id = transform.GetSiblingIndex();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
