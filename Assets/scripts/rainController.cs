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

    private void Start() {

        PoolsManager.RegisterPool(pool);
        pool.Initialize();


    }

    public float spread = 0.7f;

    public float quantiteParticleTrous = 1;

    public void makeRain(Sprite image, long quantite) {
        Debug.Log(quantite);
        float count = Mathf.Log10((float)(quantite) * quantiteParticleTrous);

        float sec = 1 / pool.Prefab.GetComponent<UIParticleSystem>().Duration;

        if (count > 0) {
            Debug.Log("moo");
            float em = 0f;

            if (count < sec)
            {
                float val = Random.Range(0, sec);
                if (count >= val)
                {
                    em = sec*1.05f;
                }
            }else {
                em = count;
            }

            Debug.Log("doo");


            if (em > sec) {
                RectTransform rect = GetComponent<RectTransform>();
                Debug.Log("soo");
                float pos = Random.Range(transform.position.x - rect.rect.width * spread, transform.position.x + rect.rect.width * spread);
                    //GameObject t = Instantiate(rain, new Vector2(pos, transform.position.y), Quaternion.identity, this.transform);
                    
                    GameObject t = pool.Spawn(new Vector3(pos, transform.position.y, 0), Quaternion.identity);
                    t.transform.parent = transform;
                RectTransform rect2 = t.GetComponent<RectTransform>();
                    rect2.position = new Vector3(pos, transform.position.y, 0);


                    rect2.localScale = new Vector3(1, 1, 1);
                    UIParticleSystem uips = t.GetComponent<UIParticleSystem>();
            uips.Particle = image;
            uips.Rotation = Random.Range(0, 30);
            uips.EmissionsPerSecond = (em);
            


            uips.Speed = Random.Range(0.05f, 0.5f);
            uips.Play();

                StartCoroutine(despawn((uips.Lifetime + uips.Duration) * 1.1f, t));

            }
            

        }

    }

    IEnumerator despawn(float time, GameObject instance) {
        yield return new WaitForSeconds(time);
        instance.Despawn();

    }

}
