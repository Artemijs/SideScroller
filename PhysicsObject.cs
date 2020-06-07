using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObject : MonoBehaviour
{
	List<Vector3> _velocities;
	public float _gravity;
	Vector3 _airVel;
	Rigidbody _body;
	public bool _inAir;
    // Start is called before the first frame update
    void Start()
    {
		_velocities = new List<Vector3>();
		_body = GetComponent<Rigidbody>();
		_inAir = true;
		_airVel = Vector3.zero;

	}

    // Update is called once per frame
    void Update()
    {
		Gravity();
		if (_velocities.Count <= 0) return;
		Vector3 total = Vector3.zero;
		foreach (Vector3 v in _velocities) {
			total += v;
		}
		transform.position += total * Time.deltaTime;
		_velocities.Clear();

	}
	void Gravity() {
		if (!_inAir) return;
		_airVel.y -= _gravity;

		_velocities.Add(_airVel);
	}
	public void AddVelocity(Vector3 vel) {
		_velocities
			.Add(vel);
	}
	public void AddAirForce(Vector3 force)
	{
		_inAir = true;
		_airVel += force;
	}
	
	private void OnCollisionEnter(Collision collision)
	{
		Vector3 colNorm = collision.GetContact(0).normal;
		if (colNorm.y > 0.85f)
		{
			Debug.Log("Grounded");
			_inAir = false;
			_airVel = Vector3.zero;
			//_animator.SetBool("inAir", _inAir);
		}
	}
	public bool InAir {
		get{ return _inAir; }

	}
}
