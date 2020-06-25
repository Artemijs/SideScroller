using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTarget : MonoBehaviour
{
	public Transform _target;
	bool _visible;
	float _width = 0;
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
		scale.x = _width;
		scale.y = _width;
		transform.localScale = scale;
		transform.LookAt(_target);
		
    }
	public bool Visible {
		get { return _visible; }
		set { _visible = value; }
	}
	public float Width
	{
		get { return _width; }
		set { _width = value; }
	}
}
