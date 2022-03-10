using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Numerics;

public class ItemController : MonoBehaviour
{



    public long id;
    public SerializableBigInteger quantite = 0;
    public SerializableBigInteger trouParTick;
    public float tickDelay;


    public SerializableBigInteger prix;
    public float coefficient;

    public SerializableBigInteger incrementTrousParClick;

    public string nom;

    [TextArea(15, 20)]
    public string description;

    public Sprite image;

    public static UnityEngine.Events.UnityEvent<long> itemEvent;


    public int unlockPalier = 1;

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
rain = GameObject.Find("Rainpos").GetComponent<rainController>();
    }

    public BigInteger getPrix() {
        if (quantite.BigInteger == 0) return prix;
        return prix * quantite * coefficient;
    }


    private BigInteger get_prix_for_qte(long qte) {
        if(qte == 0) return prix;
        BigInteger a =  (prix * qte * coefficient);
        return a;
    }


    public BigInteger get_prix(long qte)
    {
        BigInteger somme = 0;
        for (long i = 0; i < qte; i++) {
            somme += get_prix_for_qte(quantite + i);
        }

        return somme;
    }

    public IEnumerator prod() {
        yield return new WaitForSeconds(tickDelay);

        while (true) {
            TroueurGlobal.nbTrous += trouParTick*quantite;
            if (trouParTick * quantite > 0) { 
            rain.makeRain(image, trouParTick*quantite);
                itemEvent.Invoke(trouParTick * quantite);
            }

            yield return new WaitForSeconds(tickDelay);

        }

        
    }

    private rainController rain;

    // Start is called before the first frame update
    void Start()
    {

        SceneManager.sceneLoaded += OnSceneLoaded;
        if (itemEvent == null) {
            itemEvent = new UnityEngine.Events.UnityEvent<long>();
        }
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
