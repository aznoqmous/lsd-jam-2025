#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

[CustomEditor(typeof(Warp))]
public class SceneObjectSelectorEditor : Editor
{
    List<string> objectPaths = new List<string>();
    List<string> objectUuids = new List<string>();

    public override void OnInspectorGUI()
    {
        if (Application.isPlaying) return;

        serializedObject.Update();

        var sceneProp = serializedObject.FindProperty("scene");
        var pathProp = serializedObject.FindProperty("selectedGameObjectPath");
        var uuidProp = serializedObject.FindProperty("selectedGameObjectUuid");

        EditorGUILayout.PropertyField(sceneProp);

        if (sceneProp.objectReferenceValue != null)
        {
            RefreshObjectList(sceneProp.objectReferenceValue as SceneAsset);

            int selectedIndex = Mathf.Max(0, objectUuids.IndexOf(uuidProp.stringValue));
            int newIndex = EditorGUILayout.Popup(
                "GameObject",
                selectedIndex,
                objectPaths.ToArray()
            );

            pathProp.stringValue = objectPaths[newIndex];
            uuidProp.stringValue = objectUuids[newIndex];
        }

        serializedObject.ApplyModifiedProperties();
    }

    void RefreshObjectList(SceneAsset sceneAsset)
    {
        objectPaths.Clear();

        string scenePath = AssetDatabase.GetAssetPath(sceneAsset);
        Scene scene = EditorSceneManager.OpenScene(scenePath, OpenSceneMode.Additive);

        foreach (var root in scene.GetRootGameObjects())
            Collect(root, root.name);

        EditorSceneManager.CloseScene(scene, true);
    }

    void Collect(GameObject go, string path)
    {
        Warp warp = go.GetComponent<Warp>();
        if (warp != null)
        {
            objectPaths.Add(path);
            objectUuids.Add(warp.guid);
        }

        foreach (Transform child in go.transform)
            Collect(child.gameObject, path + "/" + child.name);
    }
}
#endif
