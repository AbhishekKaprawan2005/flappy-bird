using UnityEngine;

public class parallax : MonoBehaviour
{
    private MeshRenderer meshRenderer;                         // rendering the gameobject

    public float animationspeed = 1f;


    public void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(animationspeed * Time.deltaTime, 0);  //changes the position of the texture on the mesh 
    }
}
