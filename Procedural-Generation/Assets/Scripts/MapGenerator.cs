using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// class responsible for generating noise map by calling Noise class
public class MapGenerator : MonoBehaviour
{
    // enum to switch between drawing the colour and noise maps
    public enum DrawMode { NoiseMap, ColourMap, Mesh };
	public DrawMode drawMode;

	public int mapWidth;
	public int mapHeight;
	public float noiseScale;

	public int octaves;
	[Range(0, 1)]
	public float persistance;
	public float lacunarity;

	public int seed;
	public Vector2 offSet;

	public float meshHeightMultiplier;
	// animation curve so that the water is not effected by the height multiplier
	public AnimationCurve meshHeightCurve; 
	public bool autoUpdate;

	public TerrainType[] regions;

	public void GenerateMap()
	{
		float[,] noiseMap = Noise.GenerateNoiseMap(mapWidth, mapHeight, seed, noiseScale, octaves, persistance, lacunarity, offSet);

		// looping over noise map and finding region that matches and setting its colour
		Color[] colourMap = new Color[mapWidth * mapHeight];
        for(int y = 0; y < mapHeight; y++)
		{
            for(int x = 0; x < mapWidth; x++)
			{
				float currentHeight = noiseMap[x, y]; 
                for(int i = 0; i < regions.Length; i++)
				{
                    if(currentHeight <= regions[i].height)
					{
						colourMap[y * mapWidth + x] = regions[i].colour;
						break; 
					}
				}
			}
		}
		MapDisplay display = FindObjectOfType<MapDisplay>();
		if (drawMode == DrawMode.NoiseMap)
		{
			display.DrawTexture(TextureGenerator.TextureFromHeightMap(noiseMap));
		}
        else if (drawMode == DrawMode.ColourMap)
		{
			display.DrawTexture(TextureGenerator.TextureFromColourMap(colourMap, mapWidth, mapHeight));

		}
        else if (drawMode == DrawMode.Mesh)
		{
			display.DrawMesh(MeshGenerator.GenerateTerrainMesh(noiseMap, meshHeightMultiplier, meshHeightCurve), TextureGenerator.TextureFromColourMap(colourMap, mapWidth, mapHeight)); 
		}
	}

	// method to ensure that the map width and height are not less than 0 
	void OnValidate()
	{
		if (mapWidth < 1)
		{
			mapWidth = 1;
		}
		if (mapHeight < 1)
		{
			mapHeight = 1;
		}
		if (lacunarity < 1)
		{
			lacunarity = 1;
		}
		if (octaves < 0)
		{
			octaves = 0;
		}
	}
}
// struct to store tarrain type
[System.Serializable]
public struct TerrainType
	{
		public string name;
		public float height;
		public Color colour; 
	}
