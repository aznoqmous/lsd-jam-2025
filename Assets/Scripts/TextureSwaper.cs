using UnityEngine;

public class TextureSwaper : MonoBehaviour
{
    [SerializeField] MeshRenderer meshRenderer;
    [SerializeField] Texture2D textureReplacement;

    void Start()
    {
        foreach(Material m in meshRenderer.materials)
        {
            m.SetTexture("_BaseMap", textureReplacement);
            m.mainTextureScale = new Vector2(0.5f, 0.5f);
        }
    }

    void Update()
    {
        
    }
}
