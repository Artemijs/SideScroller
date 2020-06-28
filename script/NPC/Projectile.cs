using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	public GameObject _target;
	public float _speed;
	public static Main _main;
	public bool _homing = true;
	public Vector3 _direction;
	float _time ;
    // Start is called before the first frame update
    void Start()
    {
		_time = 0;

	}

    // Update is called once per frame
    void Update()
    {
		if (_homing)
		{
			transform.position += (_target.transform.position - transform.position).normalized * _speed * Time.deltaTime;
			transform.LookAt(_target.transform.position);
		}
		else {
			transform.position += _direction * _speed * Time.deltaTime;
			_time += Time.deltaTime;
			if (_time > 3) Destroy(gameObject);
		}
    }
	public void Rebound(Vector3 dir) {
		_direction = dir;
		transform.LookAt(_target.transform.position + dir*100);
		transform.position += _direction * 2;
		_homing = false;
	}
	
	
}
