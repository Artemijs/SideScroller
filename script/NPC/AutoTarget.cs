using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTarget : MonoBehaviour
{
	public Transform _target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		float dist = Vector3.Distance(transform.position, _target.position);
		Vector3 scale = transform.localScale;
		scale.z = dist;
		transform.localScale = scale;
		transform.LookAt(_target);
		
    }
}
