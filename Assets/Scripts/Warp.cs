using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Warp : MonoBehaviour
{

    [SerializeField] ScriptableLevel _targetLevel;

    [HideInInspector] public string guid = System.Guid.NewGuid().ToString();

    public SceneAsset scene;
    public string selectedGameObjectPath;
    public string selectedGameObjectUuid;

    void Start()
    {
        if (guid == SceneLoaderManager.Instance.TargetWarpGuid)
        {
            Debug.Log("Warped to me : " + name);
            SceneLoaderManager.Instance.TargetWarp = this;
        }
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("WARP !");
        StartCoroutine(SceneLoaderManager.Instance.WarpTo(scene.name, selectedGameObjectUuid));
    }


    
}

