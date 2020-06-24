using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
	GameObject _target;
	public static float _maxRange;
	float _time = 0;
	public static float _time2Fire;
	
    // Start is called before the first frame update
    void Start()
    {
		_target = GameObject.Find("Player");
		
    }

    // Update is called once per frame
    void Update()
    {
		float range = GetRange();
		if (range > _maxRange) return;
		DrawBeam();
		bool t2Fire = CheckFire();
		if (!t2Fire) return;
		Fire();
    }
	float GetRange() {
		return Vector3.Distance(_target.transform.position, transform.position);
	}
	void DrawBeam() {

	}
	bool CheckFire() {
		_time += Time.deltaTime;
		
		return (_time > _time2Fire);
	}
	void Fire() {
		_time = 0;
	}
}
