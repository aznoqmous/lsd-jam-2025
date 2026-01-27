using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Level", menuName ="Level")]
public class ScriptableLevel : ScriptableObject
{
    string _sceneName;
#if UNITY_EDITOR
    [SerializeField] UnityEditor.SceneAsset Scene;
    private void OnValidate()
    {
        if (Scene != null) _sceneName = Scene.name;
    }
#endif

    Warp Warp;
}
