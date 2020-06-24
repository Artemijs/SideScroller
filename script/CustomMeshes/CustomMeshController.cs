using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomMeshController : MonoBehaviour
{
	public Material[] _all_materials;
	CustomPlane _plane;
	public Transform start;
	public Transform end;
	void Start()
    {
		_plane = new CustomPlane(start, end, 1, _all_materials[0]);
    }

    // Update is called once per frame
    void Update()
    {
		//_plane.Update();
		_plane.Draw();

	}

}
