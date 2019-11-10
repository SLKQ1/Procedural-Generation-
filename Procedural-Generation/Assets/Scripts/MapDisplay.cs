using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// class responsible for taking the noise map and turning it into a texture then applying
// that texture to a plane
public class MapDisplay : MonoBehaviour
{
    // reference to the texture of the plane
    public Renderer textureRender;

    public void DrawNoiseMap(float[,] noiseMap)
    {
        // getting width and height of noise map
        int width = noiseMap.GetLength(0);
        int height = noiseMap.GetLength(1);

        Texture2D texture = new Texture2D(width, height);

        // creating a colour map and assigning it colours
        Color[] colourMap = new Color[width * height];
        for(int y = 0; y < height; y++)
        {
            for(int x = 0; x < width; x++)
            {
                colourMap[y * width + x] = Color.Lerp(Color.black, Color.white, noiseMap[x, y]); 
            }
        }
        texture.SetPixels(colourMap);
        texture.Apply();

        textureRender.sharedMaterial.mainTexture = texture;
        textureRender.transform.localScale = new Vector3(width, 1, height); 
    }
}
