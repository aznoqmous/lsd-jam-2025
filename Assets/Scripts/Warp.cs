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
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("WARP !");
    }

    
}

