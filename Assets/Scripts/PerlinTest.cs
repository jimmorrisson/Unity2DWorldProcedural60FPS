using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinTest : MonoBehaviour
{
    public Vector2 coordinates;
    public float perlin = 0f;

	void Update ()
    {
        perlin = Mathf.PerlinNoise(coordinates.x, coordinates.y);
	}
}
