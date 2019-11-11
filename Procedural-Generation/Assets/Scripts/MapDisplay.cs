using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// class responsible for taking the noise map and turning it into a texture then applying
// that texture to a plane
public class MapDisplay : MonoBehaviour
{
    // reference to the texture of the plane
    public Renderer textureRender;
	// ref to mesh filter and render
	public MeshFilter meshFilter;
	public MeshRenderer meshRenderer;

    public void DrawTexture(Texture2D texture)
    {
        textureRender.sharedMaterial.mainTexture = texture;
        textureRender.transform.localScale = new Vector3(texture.width, 1, texture.height); 
    }

    public void DrawMesh(MeshData meshData, Texture2D texture)
	{
		meshFilter.sharedMesh = meshData.CreateMesh();
		meshRenderer.sharedMaterial.mainTexture = texture; 
	}
}
