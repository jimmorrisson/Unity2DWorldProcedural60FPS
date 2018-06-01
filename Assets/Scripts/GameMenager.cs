using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameMenager : MonoBehaviour
{
    [SerializeField]
    Tilemap tilemap;
    [SerializeField]
    TileBase tileBase;

    public int width;
    public int height;

    void Start ()
    {
        CreateTilemap.OnLoadingFinished += LoadingFinished;
        int[,] map = new int[width, height];
        //var array = CreateTilemap.GenerateArray(100, 100, false);
        var perlinMap = CreateTilemap.PerlinNoise(map, 100);
        //for (int x = 0; x < perlinMap.GetUpperBound(0); x++)
        //{
        //    for (int y = 0; y < perlinMap.GetUpperBound(1); y++)
        //    {
        //        Debug.Log(perlinMap[x, y]);
        //    }
        //}
        //CreateTilemap.RenderMap(perlinMap, tilemap, tileBase);
        //CreateTilemap.UpdateMap(map, tilemap);
        StartCoroutine(CreateTilemap.RenderMap(map, tilemap, tileBase));
    }

    private IEnumerator RenderMap(int[,] map, Tilemap tilemap, TileBase tileBase)
    {
        yield return new WaitForSeconds(0.06f);
        CreateTilemap.RenderMap(map, tilemap, tileBase);
    }

    private void LoadingFinished()
    {
        CreateTilemap.OnLoadingFinished -= LoadingFinished;
        Debug.Log("Spawned " + CreateTilemap.TilesSpawned + " tiles");
    }
}
