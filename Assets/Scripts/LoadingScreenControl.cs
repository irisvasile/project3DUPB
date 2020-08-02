using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreenControl : MonoBehaviour
{
    public static LoadingScreenControl instance;
    public GameObject loadingScreenObj;
    public Slider slider;

    AsyncOperation async;

    public void LoadScreenExample(int lvl) {
        instance = this;
        Debug.Log("nr level " + lvl);
        StartCoroutine(LoadingScreen(lvl));
    }

    IEnumerator LoadingScreen(int lvl) {

        Debug.Log("am intrat si la scene=============");
        
        loadingScreenObj.SetActive(true);
        async = SceneManager.LoadSceneAsync(lvl);
        async.allowSceneActivation = false;

        while (async.isDone == false) {
            slider.value = async.progress;
            if (async.progress == 0.9f) {
                slider.value = 1f;
                async.allowSceneActivation = true;
            }
            yield return null;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
