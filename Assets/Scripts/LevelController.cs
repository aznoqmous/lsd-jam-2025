using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] List<Warp> _warps;

    private FileSystemWatcher _SceneFileWatcher;

    public void OnEnable()
    {
        Debug.Log("OnEnable");

        _SceneFileWatcher = new FileSystemWatcher(Path.GetFullPath("Assets/Scenes"), "*.unity");
        _SceneFileWatcher.NotifyFilter = NotifyFilters.LastWrite;
        _SceneFileWatcher.EnableRaisingEvents = true;
        _SceneFileWatcher.Changed += OnSceneFileWatcher_Changed;
    }
    void OnSceneFileWatcher_Changed(object sender, FileSystemEventArgs e)
    {
        Debug.Log("SAVE");
    }

}
