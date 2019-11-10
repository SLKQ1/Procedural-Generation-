using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// class responsible for generating noise map by calling Noise class
public class MapGenerator : MonoBehaviour
{
    public int mapWidth;
    public int mapHeight;
    public float noiseScale;

	public bool autoUpdate;

    public void GenerateMap()
    {
        float[,] noiseMap = Noise.GenerateNoiseMap(mapWidth, mapHeight, noiseScale);

        MapDisplay display = FindObjectOfType<MapDisplay>();
        display.DrawNoiseMap(noiseMap); 
    }

}
