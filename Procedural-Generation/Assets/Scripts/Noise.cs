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
    public static float[,] GenerateNoiseMap(int mapWidth, int mapHeight, int seed, float scale, int octaves, float persistance, float lacurnarity, Vector2 offSet)
    {
        float[,] noiseMap = new float[mapHeight, mapHeight];

		// sudo-random number gen
		System.Random prng = new System.Random(seed);
		Vector2[] octaveOffSets = new Vector2[octaves];
        for (int i = 0; i < octaves; i++)
		{
			float offSetX = prng.Next(-100000, 100000) + offSet.x;
			float offSetY = prng.Next(-100000, 100000) + offSet.y;
			octaveOffSets[i] = new Vector2(offSetX, offSetY); 
		}

        // handling the case where the scale is 0
        if (scale <= 0)
        {
            scale = 0.0001f; 
        }
		// vars to keep track of the min and max values
		float maxNoiseHeight = float.MinValue;
		float minNoiseHeight = float.MaxValue;

		// calc half of map
		float halfWidth = mapWidth / 2f;
		float halfHeight = mapHeight / 2f; 

        // looping over the noiseMap and assigning values
        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
				float amplitude = 1;
				float frequency = 1;
				float noiseHeight = 0;

                for (int i = 0; i < octaves; i++)
				{
					float sampleX = (x-halfWidth) / scale * frequency + octaveOffSets[i].x;
					float sampleY = (y-halfHeight) / scale * frequency + octaveOffSets[i].y;
					// getting and setting perlin noise value in map (in range -1 to 1)
					float perlinValue = Mathf.PerlinNoise(sampleX, sampleY) * 2 - 1;
					noiseHeight += perlinValue * amplitude;

					// drecrease each octave
					amplitude *= persistance;
					// increases each octave
					frequency *= lacurnarity; 
				}
                // getting the max and min height values
                if (noiseHeight > maxNoiseHeight)
				{
					maxNoiseHeight = noiseHeight; 
				} else if (noiseHeight < minNoiseHeight)
				{
					minNoiseHeight = noiseHeight; 
				}
                // setting noise map 
				noiseMap[x, y] = noiseHeight; 
			}
        }
		// normalizing the noise map (getting its values back in range 0-1)
		for (int y = 0; y < mapHeight; y++)
		{
			for (int x = 0; x < mapWidth; x++)
			{
				noiseMap[x, y] = Mathf.InverseLerp(minNoiseHeight, maxNoiseHeight, noiseMap[x, y]);
			}
		}

		return noiseMap; 
    }
}
