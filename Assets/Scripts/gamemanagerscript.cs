using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gamemanagerscript : MonoBehaviour
{
    public static gamemanagerscript instance;
    public GameObject loadingScreen;
    public ProgressBariImage bar;
    private void Awake() {
        instance = this;

        
        SceneManager.LoadSceneAsync((int) SceneIndexes.TITLE_SCREEN, LoadSceneMode.Additive);

    }
    List<AsyncOperation> scenesLoading = new List<AsyncOperation>();
    public void LoadGame() {

        loadingScreen.gameObject.SetActive(true);

        if (pauseMenu.GameIsPaused) {
            Debug.Log("am intrat cand jocul e oprit================");
            scenesLoading.Add(SceneManager.UnloadSceneAsync((int) SceneIndexes.MAP));
            scenesLoading.Add(SceneManager.LoadSceneAsync((int) SceneIndexes.TITLE_SCREEN, LoadSceneMode.Additive));
            //scenesLoading.Add(SceneManager.UnloadSceneAsync((int) SceneIndexes.TITLE_SCREEN));
            //scenesLoading.Add(SceneManager.LoadSceneAsync((int) SceneIndexes.MAP, LoadSceneMode.Additive));
            pauseMenu.GameIsPaused = false;
        }
        else {
            Debug.Log("jocul nu e pe pauza-------------------");
            scenesLoading.Add(SceneManager.UnloadSceneAsync((int) SceneIndexes.TITLE_SCREEN));
            scenesLoading.Add(SceneManager.LoadSceneAsync((int) SceneIndexes.MAP, LoadSceneMode.Additive));
        //scenesLoading.Add(SceneManager.LoadSceneAsync((int) SceneIndexes.NAVMESH, LoadSceneMode.Additive));
        }
        StartCoroutine(GetSceneLoadProgress());

    }

    float totalSceneProgress;
    public IEnumerator GetSceneLoadProgress() {
        for (int i = 0; i < scenesLoading.Count; i++) {
            while(!scenesLoading[i].isDone) {

                totalSceneProgress = 0;

                foreach(AsyncOperation operation in scenesLoading) {
                    totalSceneProgress += operation.progress;
                }

                totalSceneProgress = (totalSceneProgress / scenesLoading.Count) * 100f;
                bar.current = Mathf.RoundToInt(totalSceneProgress);
                yield return  null;
            }
        }

        loadingScreen.gameObject.SetActive(false);
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
