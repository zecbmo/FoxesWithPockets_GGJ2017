using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UVFucker : MonoBehaviour {

    // Use this for initialization

    Mesh mesh;
    float offset = 0;
	void Start ()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;
        Vector2[] uvs = new Vector2[vertices.Length];

        for (int i = 0; i < uvs.Length; i++)
        {
            uvs[i] = new Vector2(vertices[i].x, 0);
        }
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        Vector3[] vertices = mesh.vertices;
        Vector2[] uvs = new Vector2[vertices.Length];

        offset += 0.02f * Time.deltaTime;

        for (int i = 0; i < uvs.Length; i++)
        {
            uvs[i] = new Vector2(vertices[i].x + offset, vertices[i].y);
        }
        mesh.uv = uvs;
    }
}
