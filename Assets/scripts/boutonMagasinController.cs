using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class boutonMagasinController : MonoBehaviour
{
    

    [SerializeField] private string _sceneName = "maingame";
    public string _SceneName => this._sceneName;

    private AsyncOperation _asyncOperation;


    // Start is called before the first frame update
    void Start()
    {
        //this.StartCoroutine(this.LoadSceneAsyncProcess(sceneName: this._sceneName));
    }    
/*
    private IEnumerator LoadSceneAsyncProcess(string sceneName)
    {
        // Begin to load the Scene you have specified.
        this._asyncOperation = SceneManager.LoadSceneAsync(sceneName);

        // Don't let the Scene activate until you allow it to.
        this._asyncOperation.allowSceneActivation = false;

        while (!this._asyncOperation.isDone)
        {
            Debug.Log($"[scene]:{sceneName} [load progress]: {this._asyncOperation.progress}");

            yield return null;
        }
    }
*/
    public void onClick() {
        GameObject.Find("soundManager").GetComponent<soundManagerController>().playSelect();
        GameObject.Find("items and upgrades").GetComponent<save>().saveAll();
  //      this._asyncOperation.allowSceneActivation = true;
        SceneManager.LoadScene(_sceneName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
