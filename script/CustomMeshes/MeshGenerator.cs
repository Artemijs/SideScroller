﻿using System.Collections;
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
	public float _width;
	Vector3 _oStart;
	public bool _visible;
	Vector3 _oEnd;
	// Start is called before the first frame update
	void Start()
    {
		_verts = new Vector3[4];
		_uvs = new Vector2[4];
		_tris = new int[6];
		_mesh = new Mesh();
		Vector3 p1 = transform.position;
		Vector3 p2 = _end.position;

		_oStart = transform.position;
		_oEnd = _end.position;

		_verts[0] = p2;
		_verts[1] = p1;
		p2.y -= _width;
		_verts[2] = p2;
		p1.y -= _width;
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
		/*if (!_visible) return;
		if (_oStart != transform.position || _oEnd != _end.position) {
			UpdateMesh();
		}*/
		
		Graphics.DrawMesh(_mesh, Vector3.zero, Quaternion.identity, _mat, 0);
	}/*
	void UpdateMesh() {
		Vector3 p1 = transform.position;
		Vector3 p2 = _end.position;
		_oStart = p1;
		_oEnd = p2;
		Vector3 dir = (_end.position - transform.position).normalized;
		if (p1.x < p2.x) {
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
	}
	Vector3 GetVert(Vector3 p, Vector3 dir, float len)
	{
		dir = new Vector3(-dir.y, dir.x, 0);
		return p + (dir * len);
	}
	Vector3 GetVert(Vector3 p, float len) {
		Vector3 dir = (_end.position - _start.position).normalized;
		dir = new Vector3(-dir.y, dir.x, 0);
		return p + (dir * len);
	}*/
}
/*_verts[0] = p2;
		_verts[1] = p1;
		p2.y -= _width;
		_verts[2] = p2;
		p1.y -= _width;
		_verts[3] = p1;*/
