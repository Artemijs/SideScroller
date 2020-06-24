using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGenerator : MonoBehaviour
{
	Vector3[] _verts;
	Vector2[] _uvs;
	int[] _tris;
	Mesh _mesh;
	public Material _mat;
	public Transform _start;
	public Transform _end;
	// Start is called before the first frame update
	void Start()
    {
		_verts = new Vector3[4];
		_uvs = new Vector2[4];
		_tris = new int[6];
		_mesh = new Mesh();
		Vector3 p1 = _start.position;
		Vector3 p2 = _end.position;
		/*_verts[0] = new Vector3(-1.0f, 1.0f, 0f); //uvs 00
		_verts[1] = new Vector3(1.0f, 1.0f, 0f);

		_verts[2] = new Vector3(-1.0f, -1.0f, 0f);
		_verts[3] = new Vector3(1.0f, -1.0f, 0f);
		*/
		_verts[0] = p2;
		_verts[1] = p1;
		p2.y -= 2;
		_verts[2] = p2;
		p1.y -= 2;
		_verts[3] = p1;

		_uvs[0] = new Vector2(0.0f, 0.0f);
		_uvs[1] = new Vector2(1.0f, 0.0f);
		_uvs[2] = new Vector2(0.0f, 1.0f);
		_uvs[3] = new Vector2(1.0f, 1.0f);

		_tris[0] = 0;
		_tris[1] = 1;
		_tris[2] = 3;

		_tris[3] = 0;
		_tris[4] = 3;
		_tris[5] = 2;

		_mesh.vertices = _verts;
		_mesh.uv = _uvs;
		_mesh.triangles = _tris;
		_mesh.RecalculateBounds();
		_mesh.RecalculateNormals();


	}
	
	private void Update()
	{
		UpdateMesh();
		Graphics.DrawMesh(_mesh, transform.position, Quaternion.identity, _mat, 0);
	}
	void UpdateMesh() {
		Vector3 p1 = _start.position;
		Vector3 p2 = _end.position;
		if (p1.x < p2.x) {
			Vector3 temp = p2;
			p2 = p1;
			p1 = temp;
		}
		_verts[0] = p2;
		_verts[1] = p1;
		p2.y -= 2;
		_verts[2] = p2;
		p1.y -= 2;
		_verts[3] = p1;
		_mesh.vertices = _verts;
	}
}
