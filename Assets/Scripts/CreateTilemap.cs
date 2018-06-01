using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CreateTilemap : MonoBehaviour
{
    public static float maxLoopTime = 16.0f; // miliseconds
    public static int TilesSpawned { get; private set; }
    public static event Action OnLoadingFinished;
    public static int[,] GenerateArray(int width, int height, bool empty)
    {
        int[,] array = new int[width, height];
        for (int x = 0; x < array.GetUpperBound(0); x++)
        {
            for (int y = 0; y < array.GetUpperBound(1); y++)
            {
                array[x, y] = (empty) ? 0 : 1;
            }
        }
        return array;
    }

    public static IEnumerator RenderMap(int[,] map, Tilemap tilemap, TileBase tile)
    {
        tilemap.ClearAllTiles();

        StopWatch stopWatch = new StopWatch();

        stopWatch.Start();
        for (int x = 0; x < map.GetUpperBound(0); x++)
        {
            for (int y = 0; y < map.GetUpperBound(1); y++)
            {
                if (map[x, y] == 1)
                {
                    tilemap.SetTile(new Vector3Int(x, y, 0), tile);
                    TilesSpawned++;
                    if (stopWatch.ElapsedMilliseconds > maxLoopTime)
                    {
                        yield return null;
                        stopWatch.Reset();
                        stopWatch.Start();
                    }
                }
            }
        }
        if (OnLoadingFinished != null) { OnLoadingFinished(); }
    }

    public static void UpdateMap(int[,] map, Tilemap tilemap)
    {
        for (int x = 0; x < map.GetUpperBound(0); x++)
        {
            for (int y = 0; y < map.GetUpperBound(1); y++)
            {
                if (map[x, y] == 0)
                {
                    tilemap.SetTile(new Vector3Int(x, y, 0), null);
                }
            }
        }
    }

    public static int[,] PerlinNoise(int[,] map, float seed)
    {
        int newPoint;
        float reduction = .5f;

        for (int x = 0; x < map.GetUpperBound(0); x++)
        {
            //newPoint = Mathf.FloorToInt(Mathf.PerlinNoise(x, seed) - reduction) * map.GetUpperBound(1);
            //newPoint += (map.GetUpperBound(1) / 2);
            newPoint = Mathf.FloorToInt(Mathf.PerlinNoise(x, UnityEngine.Random.Range(-100, 100) / 100.0f) * 50);
            for (int y = newPoint; y >= 0; y--)
            {
                map[x, y] = 1;
            }
        }
        return map;
    }
}
