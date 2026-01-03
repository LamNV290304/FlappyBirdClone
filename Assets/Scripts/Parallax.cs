using UnityEngine;

public class Parallax : MonoBehaviour
{
    private MeshRenderer meshRenderer;


    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(0.5f, 0) * Time.deltaTime;
    }

}
