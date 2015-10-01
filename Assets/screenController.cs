using UnityEngine;
using System.Collections;

public class screenController : MonoBehaviour {

	public Vector2 screenSize = new Vector2 (16,15);

	Vector3[] vertices = new Vector3[960];
	int[] triangles = new int[1440];
	Vector2[] uv = new Vector2[960];

	void Start () {

		Mesh screen = new Mesh();

		screen.vertices = new Vector3[Mathf.RoundToInt(screenSize.x * screenSize.y * 4)];
		screen.triangles = new int[Mathf.RoundToInt(screenSize.x * screenSize.y * 6)];
		screen.uv = new Vector2[Mathf.RoundToInt(screenSize.x * screenSize.y * 4)];

		for (int x = 0; x < screenSize.x; x++) {

			for (int y = 0; y < screenSize.y; y++) {

				vertices[(x*screenSize.y+y)*4]   = new Vector3(x,y,0);
				vertices[(x*screenSize.y+y)*4+1] = new Vector3(x+1,y,0);
				vertices[(x*screenSize.y+y)*4+2] = new Vector3(x,y+1,0);
				vertices[(x*15+y)*4+3] = new Vector3(x+1,y+1,0);

				triangles[(x*screenSize.y+y)*6]   = (x*15+y)*4;
				triangles[(x*screenSize.y+y)*6+1] = (x*15+y)*4+3;
				triangles[(x*screenSize.y+y)*6+2] = (x*15+y)*4+1;

				triangles[(x*screenSize.y+y)*6+3] = (x*15+y)*4;
				triangles[(x*screenSize.y+y)*6+4] = (x*15+y)*4+2;
				triangles[(x*screenSize.y+y)*6+5] = (x*15+y)*4+3;

				uv[(x*screenSize.y+y)*4]   = new Vector2 (0,0);
				uv[(x*screenSize.y+y)*4+1] = new Vector2 (1,0);
				uv[(x*screenSize.y+y)*4+2] = new Vector2 (0,1);
				uv[(x*screenSize.y+y)*4+3] = new Vector2 (1,1);

			}
		}

		screen.vertices = vertices;
		screen.uv = uv;
		screen.triangles = triangles;

		screen.RecalculateNormals();
		gameObject.GetComponent<MeshFilter> ().mesh = screen;

	}

}