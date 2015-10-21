using UnityEngine;
using System.Collections;

public class editorScreen : MonoBehaviour {

    private MeshFilter graphics; 
    private Mesh screen;
    private Camera mainCamera;
    public int height = 15;
    public int width = 16;
    public Vector2 lowerLeft;
    public Vector2 upperLeft;
    public Vector2 lowerRight;
    public Vector2 upperRight;


    void Start () {
        graphics = gameObject.GetComponent<MeshFilter>();
        screen = graphics.mesh;
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        lowerLeft = mainCamera.WorldToScreenPoint(screen.vertices[0]);
        upperRight = mainCamera.WorldToScreenPoint(screen.vertices[width * height * 4 - 1]);
        lowerRight = mainCamera.WorldToScreenPoint(screen.vertices[width * 4-3]);
        upperLeft = mainCamera.WorldToScreenPoint(screen.vertices[width * (height-1) * 4 + 3]);
    }
	
	void Update () {
	
	}
}