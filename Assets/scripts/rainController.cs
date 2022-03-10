using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuickPool;


public class rainController : MonoBehaviour
{

    public Pool pool = new Pool()
    {
        size = 100,
        allowGrowth = true
    };


    public float rainChance = 0.2f;


    public void resetMax() {
        maxQuantity = 0;
        minQuantity = -1;

        foreach (Transform child in transform) {
            child.gameObject.Despawn();
        }

    }


    private void Start() {

        instance = this;
        int i = 0;

        

        foreach (var gameObj in FindObjectsOfType(typeof(GameObject)) as GameObject[])
        {
            if (gameObj.name == this.gameObject.name)
            {
                i++;
                if (i > 1)
                {
                    Destroy(this.gameObject);
                }
            }
        }

        PoolsManager.RegisterPool(pool);
        pool.Initialize();


    }

    public float spread = 0.7f;

    public float quantiteParticleTrous = 1;

    private long maxQuantity=0;
    private long minQuantity = -1;

    public static rainController instance;

    public void makeRain(Sprite image, long quantite) {

        if(quantite > maxQuantity) maxQuantity = quantite;

        if(minQuantity < 0 || quantite < minQuantity) minQuantity = quantite;

        if ( (rainChance/( (pool.spawned.Count)/(pool.size*1.1f) + 1))* Mathf.Max((quantite*1.5f)/maxQuantity ,1) >= Random.Range(0f, 1f)) { 
            
            

        float count = (Mathf.Log10((float)(quantite) * quantiteParticleTrous + 0.5f));

            Debug.Log("count rain = " + count);

            float sec = 1 / pool.Prefab.GetComponent<UIParticleSystem>().Duration;

        if (count > 0) {
            
            float em = 0f;

            if (count < sec)
            {
                float val = Random.Range(0, sec);
                if (count >= val)
                {
                    em = sec*1.05f;
                }
            }else {
                em = count * Random.Range(0.4f, 1f);
            }

            


            if (em > sec) {
                RectTransform rect = GetComponent<RectTransform>();
                
                float pos = Random.Range(transform.position.x - rect.rect.width * spread, transform.position.x + rect.rect.width * spread);
                    //GameObject t = Instantiate(rain, new Vector2(pos, transform.position.y), Quaternion.identity, this.transform);
                    
                    GameObject t = pool.Spawn(new Vector3(pos, transform.position.y, 0), Quaternion.identity);
                    t.transform.SetParent(transform, false);
                RectTransform rect2 = t.GetComponent<RectTransform>();
                    rect2.position = new Vector3(pos, transform.position.y, 0);


                    rect2.localScale = new Vector3(1, 1, 1);
                    UIParticleSystem uips = t.GetComponent<UIParticleSystem>();
            uips.Particle = image;
            uips.Rotation = Random.Range(0, 30);
            uips.EmissionsPerSecond = (em);
            


            uips.Speed = Random.Range(0.05f, 0.5f);
            uips.Play();

                StartCoroutine(despawn((uips.Lifetime + uips.Duration) * 1.05f, t));

            }
            

        }
        }

    }

    IEnumerator despawn(float time, GameObject instance) {
        Debug.Log(gameObject);
        yield return new WaitForSeconds(time);

        instance.Despawn();
        yield return null;
    }

}
