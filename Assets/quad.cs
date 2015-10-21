using UnityEngine;
using System.Collections;

[System.Serializable]

public struct quad {

    public index position;
    public Vector3[] vertices;
    public Vector2[] uvs;
    public int[] lookup;

    public quad (index Position, Vector3[] Vertices, Vector2[] UVs, int[] Lookup)
    {
        position = Position;
        vertices = Vertices;
        uvs = UVs;
        lookup = Lookup;
    }
}