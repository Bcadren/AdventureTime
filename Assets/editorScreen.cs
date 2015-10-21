using UnityEngine;
using System.Collections;

public class editorScreen : MonoBehaviour {

    private MeshFilter graphics; 
    private Mesh screen;
    private Camera mainCamera;
    private screenMath math;

    public int height = 15;
    public int width = 16;

    public Vector2 lowerLeft;
    public Vector2 upperLeft;
    public Vector2 lowerRight;
    public Vector2 upperRight;

    void Start ()

    {
        graphics = gameObject.GetComponent<MeshFilter>();
        screen = graphics.mesh;
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        math = new screenMath(width, height, screen);

        lowerLeft = mainCamera.WorldToScreenPoint(screen.vertices[math.lookup(0, 0)[0]]);
        upperRight = mainCamera.WorldToScreenPoint(screen.vertices[math.lookup(width, height)[3]]);
        lowerRight = mainCamera.WorldToScreenPoint(screen.vertices[math.lookup(width, 0)[1]]);
        upperLeft = mainCamera.WorldToScreenPoint(screen.vertices[math.lookup(0, height)[2]]);

    }
	
	void Update () {
	
	}
}