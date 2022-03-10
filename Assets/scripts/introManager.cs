using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
public class introManager : MonoBehaviour
{


    [SerializeField] private string _sceneName;
    public string _SceneName => this._sceneName;

    private AsyncOperation _asyncOperation;

    public GameObject dontDestroyOnLoad;

    
    private void Start() {
        GameObject.Find("soundManager").GetComponent<soundManagerController>().playIntroJingle();
        this.StartCoroutine(this.LoadSceneAsyncProcess(sceneName: this._sceneName));
        DontDestroyOnLoad(dontDestroyOnLoad);

    }

    public void allowLoad() {
        //SceneManager.LoadScene(_sceneName);
        this._asyncOperation.allowSceneActivation = true;

        
    }

    

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

}
