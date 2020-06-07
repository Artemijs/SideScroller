using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObject : MonoBehaviour
{
	List<Vector3> _velocities;
    // Start is called before the first frame update
    void Start()
    {
		_velocities = new List<Vector3>();

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

	}
	public void AddVelocity(Vector3 vel) {
		_velocities
			.Add(vel);
	}
}
