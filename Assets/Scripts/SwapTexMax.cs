using UnityEngine;
using UnityEngine.InputSystem;

public class SwapTexMax : MonoBehaviour
{
    [SerializeField] Texture2D tex;
    [SerializeField] Texture2D tex2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Shader.SetGlobalTexture("_MainTex", tex);
        Shader.SetGlobalTexture("_OverrideTexture", tex2);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            SwapTexture();
        }
    }

    private void SwapTexture()
    {
        Debug.Log("marche");
        Shader.SetGlobalTexture("_MainTex", tex2);

    }
}
