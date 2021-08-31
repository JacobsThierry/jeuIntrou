using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManagerController : MonoBehaviour
{

    private List<GameObject> sounds = new List<GameObject>();
    public float volume;

    public List<AudioClip> hit;
    public AudioClip buySound;
    public AudioClip select;

    public void playSelect() {
        playSound(select);
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


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject o in sounds) {
            AudioSource audioSource = o.GetComponent<AudioSource>();
            audioSource.volume = volume;
        }
    }
}
