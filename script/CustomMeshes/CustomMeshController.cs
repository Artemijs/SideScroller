using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomMeshController : MonoBehaviour
{
	public Material[] _all_materials;

	public Transform start;
	public Transform end;
	void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {


	}
	public CustomPlane GetPlane() {
		return new CustomPlane( 0.1f, _all_materials[0]) ;

	}
}
