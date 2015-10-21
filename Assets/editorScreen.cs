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
    public Vector2 upperRight;

    public index debugVar;
    public int[] debugVar0;

    void Start ()

    {
        graphics = gameObject.GetComponent<MeshFilter>();
        screen = graphics.mesh;
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        math = new screenMath(width, height, screen);

        lowerLeft = mainCamera.WorldToScreenPoint(screen.vertices[math.lookup(0, 0)[0]] + transform.position);
        upperRight = mainCamera.WorldToScreenPoint(screen.vertices[math.lookup(width-1, height-1)[3]] + transform.position);
        
    }
	
	void Update ()
    {
	    if (Input.GetButtonDown("Fire1"))
        {
            if ((Input.mousePosition.x > lowerLeft.x) && (Input.mousePosition.y > lowerLeft.y) && (Input.mousePosition.x < upperRight.x) && (Input.mousePosition.y < upperRight.y))
            {
                index mousePosition = new index(Mathf.FloorToInt(((Input.mousePosition.x - lowerLeft.x)/(upperRight.x - lowerLeft.x)) * width), Mathf.FloorToInt(((Input.mousePosition.y - lowerLeft.y)/(upperRight.y-lowerLeft.y)) * height));
                debugVar = mousePosition;
                editUV(mousePosition, new Vector2[4] { new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 0), new Vector2(1, 1)});
            }
        }
	}

    void editUV (index location, Vector2[] newUVs)
    {
        int[] activeSpace = math.lookup(location);
        debugVar0 = activeSpace;
        Vector2[] tempUVs = screen.uv;
        for (int i = 0; i < activeSpace.Length; i++)
        {
            tempUVs[activeSpace[i]] = newUVs[i];
        }

        screen.uv = tempUVs;
        graphics.mesh = screen;

    }
}