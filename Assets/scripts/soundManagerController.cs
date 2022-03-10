using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManagerController : MonoBehaviour
{

    private List<GameObject> sounds = new List<GameObject>();

    public AudioClip musique;
    public float volume;

    public static soundManagerController instance;


    public List<AudioClip> sonsIntro;

    public AudioClip poorPiouPiou;
    public List<AudioClip> hit;
    public AudioClip buySound;
    public AudioClip select;
    private AudioSource asMusique;
    public AudioClip sonPiouPiou;

    private bool _musiqueOn=true;

    public bool musiqueOn{

        get {
            return _musiqueOn;
        }

        set{
            _musiqueOn = value;
            asMusique.volume = value ? volume : 0;

        }
    }

    public void playIntroJingle() {
        playSound(sonsIntro[Random.Range(0, sonsIntro.Count)]);
    }

    public void setupMusique() {

        if (transform.Find("Musique") == null) {
            GameObject go = new GameObject("Musique");
            go.transform.parent = transform;
            asMusique = go.AddComponent<AudioSource>();
            asMusique.clip = musique;
            asMusique.volume = volume;
            asMusique.loop = true;
            asMusique.Play();
        }
    }

    private void Start() {
        instance = this;

    }

public void playPiouPiou(){
        playSound(sonPiouPiou);
    }


public void playSelect() {
        playSound(select);
    }


    

    public void playPoorPiouPiou() {
        playSound(poorPiouPiou);
    }

    public void playHit(){
        AudioClip r = hit[Random.Range(0, hit.Count)];
        playSound(r);
    }

    public void playBuy() {
        playSound(buySound);
    }

    public void playSound(AudioClip ac) {
        GameObject go = new GameObject("sound");
        go.transform.parent = transform;
        AudioSource audioSource = go.AddComponent<AudioSource>();
        audioSource.clip = ac;
        audioSource.volume = volume;
        go.AddComponent<destroyAudio>();
        audioSource.Play();
    }



    // Update is called once per frame
    void Update()
    {
        if(asMusique != null)
            asMusique.volume = musiqueOn?volume:0;
        
        foreach (GameObject o in sounds) {
            AudioSource audioSource = o.GetComponent<AudioSource>();
            audioSource.volume = volume;
        }
    }
}
