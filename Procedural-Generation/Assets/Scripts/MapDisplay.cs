using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// class responsible for taking the noise map and turning it into a texture then applying
// that texture to a plane
public class MapDisplay : MonoBehaviour
{
    // reference to the texture of the plane
    public Renderer textureRender;

    public void DrawTexture(Texture2D texture)
    {
        textureRender.sharedMaterial.mainTexture = texture;
        textureRender.transform.localScale = new Vector3(texture.width, 1, texture.height); 
    }
}
