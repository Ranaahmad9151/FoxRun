using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class WaterMover : MonoBehaviour
{
    public Material mat;
    public float speed = 1.0f;
    private void Start()
    {
        InvokeRepeating("Animate",0.01f,0.01f);
    }

    private void Animate()
    {
        if (mat.mainTextureOffset.y < 100000)
        {
            mat.mainTextureOffset += new Vector2(0, -0.1f*speed);
        }
        if (mat.mainTextureOffset.y >= 100000)
        {
            mat.mainTextureOffset = Vector2.zero;
        }
        
    }

 
}
