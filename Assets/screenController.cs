using UnityEngine;
using UnityEditor;
using System.Collections;

public class screenController : MonoBehaviour {

	public index screenSize = new index (16,15);
	public string screenName = "screen";
	
	void Start () {

		Vector3[] vertices = new Vector3[screenSize.x * screenSize.y * 4];
		int[] triangles = new int[screenSize.x * screenSize.y * 6];
		Vector2[] uv = new Vector2[screenSize.x * screenSize.y * 4];

		Mesh screen = new Mesh();

		screen.vertices = new Vector3[screenSize.x * screenSize.y * 4];
		screen.triangles = new int[screenSize.x * screenSize.y * 6];
		screen.uv = new Vector2[screenSize.x * screenSize.y * 4];

		for (int x = 0; x < screenSize.x; x++) {

			for (int y = 0; y < screenSize.y; y++) {

				vertices[(y*screenSize.x+x)*4]   = new Vector3(x,y,0);
				vertices[(y*screenSize.x+x)*4+1] = new Vector3(x+1,y,0);
				vertices[(y*screenSize.x+x)*4+2] = new Vector3(x,y+1,0);
				vertices[(y*screenSize.x+x)*4+3] = new Vector3(x+1,y+1,0);

				triangles[(y*screenSize.x+x)*6]   = (x*screenSize.y+y)*4;
				triangles[(y*screenSize.x+x)*6+1] = (x*screenSize.y+y)*4+3;
				triangles[(y*screenSize.x+x)*6+2] = (x*screenSize.y+y)*4+1;

				triangles[(y*screenSize.x+x)*6+3] = (x*screenSize.y+y)*4;
				triangles[(y*screenSize.x+x)*6+4] = (x*screenSize.y+y)*4+2;
				triangles[(y*screenSize.x+x)*6+5] = (x*screenSize.y+y)*4+3;

				uv[(y*screenSize.x+x)*4]   = new Vector2 (0.5f,0f);
				uv[(y*screenSize.x+x)*4+1] = new Vector2 (0.75f,0f);
				uv[(y*screenSize.x+x)*4+2] = new Vector2 (0.5f,0.25f);
				uv[(y*screenSize.x+x)*4+3] = new Vector2 (0.75f,0.25f);

			}
		}

		screen.vertices = vertices;
		screen.uv = uv;
		screen.triangles = triangles;

		screen.RecalculateNormals();
		gameObject.GetComponent<MeshFilter> ().mesh = screen;
		AssetDatabase.CreateAsset (screen, "Assets/" + screenName + ".asset");

	}

}