using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderManager : MonoBehaviour
{
    public string TargetWarpGuid = string.Empty;
    public Warp TargetWarp;

    bool _isLoading = false;

    public static SceneLoaderManager Instance;
    private void Awake()
    {
        Instance = this;
        Debug.Log("BOOTSTRAPPED");
    }
    [SerializeField] Animator _loadingScreenAnimator;

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneProgress(sceneName));
    }

    public IEnumerator LoadSceneProgress(string sceneName)
    {
        if (!_isLoading)
        {
            _isLoading = true;

            //_loadingScreenAnimator.SetBool("IsLoading", true);
            yield return new WaitForSeconds(1f);
            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
            operation.allowSceneActivation = false;
            while (operation.progress < 0.9f)
            {
                yield return new WaitForEndOfFrame();
            }
            operation.allowSceneActivation = true;
            //_loadingScreenAnimator = GetComponent<Animator>();
            //_loadingScreenAnimator.SetBool("IsLoading", false);

            _isLoading = false;
        }
    }

    public IEnumerator LoadTitleScene()
    {
        yield return StartCoroutine(LoadSceneProgress("TitleScene"));
    }

    public IEnumerator LoadDailyRun()
    {
        yield return StartCoroutine(LoadSceneProgress("DailyRun"));
    }

    public IEnumerator LoadRun()
    {
        yield return StartCoroutine(LoadSceneProgress("RunScene"));
    }

    public IEnumerator ReloadScene()
    {
        yield return StartCoroutine(LoadSceneProgress(SceneManager.GetActiveScene().name));
    }

    public IEnumerator WarpTo(string sceneName, string warpUuid)
    {
        yield return StartCoroutine(LoadSceneProgress(sceneName));
        TargetWarpGuid = warpUuid;
    }
}