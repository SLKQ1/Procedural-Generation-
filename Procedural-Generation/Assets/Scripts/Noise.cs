using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noise
{
    // method that will generate the noise map
    // params:
    // mapWidth: int for width of map
    // mapHeight: int for map height
    // scale: float value that will scale the noise map
    //
    // return: noise map (2d float arr) 
    public static float[,] GenerateNoiseMap(int mapWidth, int mapHeight, float scale)
    {
        float[,] noiseMap = new float[mapHeight, mapHeight];
        // handling the case where the scale is 0
        if (scale <= 0)
        {
            scale = 0.0001f; 
        }
        // looping over the noiseMap and assigning values
        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                float sampleX = x / scale;
                float sampleY = y / scale; 
            }
        }
        return noiseMap; 
    }
}
