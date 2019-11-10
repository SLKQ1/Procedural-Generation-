using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// class responsible for creating a texture from a 1d colour map 
public static class TextureGenerator
{
    // method to get a texture from colour map 
    public static Texture2D TextureFromColourMap(Color[] colourMap, int width, int height)
    {
        Texture2D texture = new Texture2D(width, height);
        texture.filterMode = FilterMode.Point;
        texture.wrapMode = TextureWrapMode.Clamp; 
        texture.SetPixels(colourMap);
        texture.Apply();

        return texture; 
    }

    // method to get a texture from a 2d height map
    public static Texture2D TextureFromHeightMap(float[,] heightMap)
    {
        // getting width and height of noise map
        int width = heightMap.GetLength(0);
        int height = heightMap.GetLength(1);
      
        // creating a colour map and assigning it colours
        Color[] colourMap = new Color[width * height];
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                colourMap[y * width + x] = Color.Lerp(Color.black, Color.white, heightMap[x, y]);
            }
        }
        return TextureFromColourMap(colourMap, width, height); 

    }
}
