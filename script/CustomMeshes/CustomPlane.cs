using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomPlane
{
	Vector3[] _verts;
	Vector2[] _uvs;
	int[] _tris;
	Mesh _mesh;
	Vector3 _oStart;
	bool _visible;
	Vector3 _oEnd;

	public Material _mat;
	public Transform _start;
	public Transform _end;
	float _width;
	public CustomPlane( float width, Material mat)
	{
		_visible = false;
		_mat = mat;
		_verts = new Vector3[4];
		_uvs = new Vector2[4];
		_tris = new int[6];
		_mesh = new Mesh();
		_width = width;

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
	public CustomPlane(Transform start, Transform end, float width, Material mat) {
		_visible = true;
		_mat = mat;
		_verts = new Vector3[4];
		_uvs = new Vector2[4];
		_tris = new int[6];
		_mesh = new Mesh();
		_width = width;
		_start = start;
		_end = end;

		Vector3 p1 = start.position;
		Vector3 p2 = _end.position;
		_oStart = _start.position;
		_oEnd = _end.position;
		//p1 = new Vector3(-5, 3, 0);
		//p2 = new Vector3(-6, 3, 0);
		_verts[0] = GetVert(p1, _width);
		_verts[1] = GetVert(p2, _width);
		_verts[2] = GetVert(p1, -_width);
		_verts[3] = GetVert(p2, -_width);


		/*_verts[0] = new Vector3(-1, 1);
		_verts[1] = new Vector3(1, 1);
		_verts[2] = new Vector3(-1, -1);
		_verts[3] = new Vector3(1, -1);*/

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

	public void Update()
	{
		if (!_visible) return;
		if (_oStart != _start.position || _oEnd != _end.position)
		{
			UpdateMesh();
		}


	}
	public void Draw() {
		if (!_visible) return;
		Graphics.DrawMesh(_mesh, Vector3.zero, Quaternion.identity, _mat, 0);
	}
	void UpdateMesh()
	{
		Vector3 p1 = _start.position;
		Vector3 p2 = _end.position;
		_oStart = p1;
		_oEnd = p2;
		Vector3 dir = (_end.position - _start.position).normalized;
		if (p1.x < p2.x)
		{
			_verts[0] = GetVert(p2, dir, _width);
			_verts[1] = GetVert(p1, dir, _width);
			_verts[2] = GetVert(p2, dir, -_width);
			_verts[3] = GetVert(p1, dir, -_width);
		}
		_verts[0] = GetVert(p1, dir, _width);
		_verts[1] = GetVert(p2, dir, _width);
		_verts[2] = GetVert(p1, dir, -_width);
		_verts[3] = GetVert(p2, dir, -_width);
		_mesh.vertices = _verts;
		_mesh.RecalculateBounds();
		_mesh.RecalculateNormals();
	}
	Vector3 GetVert(Vector3 p, Vector3 dir, float len)
	{
		dir = new Vector3(-dir.y, dir.x, 0);
		return p + (dir * len);
	}
	Vector3 GetVert(Vector3 p, float len)
	{
		Vector3 dir = (_end.position - _start.position).normalized;
		dir = new Vector3(-dir.y, dir.x, 0);
		return p + (dir * len);
	}
	public bool Visible{
		get { return _visible; }
		set { _visible = value; }
	}

	public float Width { get => _width; set =>_width = value; }

	public void SetEndPoints(Transform start, Transform end) {
		_start = start;
		_end = end;
		_oStart = start.position;
		_oEnd = end.position;
	}
}
/*
 _verts[0] = p2;
		_verts[1] = p1;
		p2.y -= _width;
		_verts[2] = p2;
		p1.y -= _width;
		_verts[3] = p1;*/
