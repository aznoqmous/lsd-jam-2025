using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

[InitializeOnLoad]
public static class LevelEditor
{
    static LevelEditor()
    {
        EditorSceneManager.sceneSaving += OnSceneSaving;
    }

    private static void OnSceneSaving(Scene scene, string path)
    {
        Debug.Log($"Scene is being saved: {scene.name}");
        List<Warp> warps = FindAllObjectsOfTypeExpensive<Warp>().ToList();
        Debug.Log($"Found {warps.Count} warps !");
        foreach(Warp warp in warps)
        {
            Debug.Log(warp.name + " : " + warp.guid);
        }
    }

    public static IEnumerable<GameObject> GetAllRootGameObjects()
    {
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            GameObject[] rootObjs = SceneManager.GetSceneAt(i).GetRootGameObjects();
            foreach (GameObject obj in rootObjs)
                yield return obj;
        }
    }

    public static IEnumerable<T> FindAllObjectsOfTypeExpensive<T>()
        where T : MonoBehaviour
    {
        foreach (GameObject obj in GetAllRootGameObjects())
        {
            foreach (T child in obj.GetComponentsInChildren<T>(true))
                yield return child;
        }
    }
}
