using System.Collections;
using System.Collections.Generic;
using UnityEngine;
enum TurretState {
	IDLE,
	TARGETING,
	COOLING_DOWN
};
public class Turret : MonoBehaviour
{
	GameObject _target;
	public  float _maxRange;
	float _time = 0;
	public  float _time2Fire;
	AutoTarget _laserTarget;
	TurretState _tState;
	public float _fireRate;
    // Start is called before the first frame update
    void Start()
    {
		_target = GameObject.Find("Player");
		_laserTarget = transform.GetChild(0).GetComponent<AutoTarget>();


	}

	// Update is called once per frame
	void Update()
    {

		if (_tState == TurretState.IDLE)
		{
			float range = GetRange();
			if (range > _maxRange) return;
			else if (_laserTarget.Visible != true)
			{
				_laserTarget.Visible = true;
				_tState = TurretState.TARGETING;
			}

		}
		else if (_tState == TurretState.TARGETING) {

			Debug.Log("In range");
			DrawBeam();
			bool t2Fire = CheckFire();
			if (!t2Fire) return;
			Fire();
			_tState = TurretState.COOLING_DOWN;
		}
		else if (_tState == TurretState.COOLING_DOWN) {
			_time += Time.deltaTime;
			if (_time >= _fireRate) {
				_time = 0;
				_tState = TurretState.IDLE;
			}

		}

		if (GetRange() > _maxRange && _tState != TurretState.IDLE)
		{
			_tState = TurretState.IDLE;
			_laserTarget.Visible = false;
			_time = 0;
		}
	}
	float GetRange() {
		return Vector3.Distance(_target.transform.position, transform.position);
	}
	void DrawBeam() {
		_laserTarget.Width = 0.1f * (_time / _time2Fire);
		
	}
	bool CheckFire() {
		_time += Time.deltaTime;
		
		return (_time > _time2Fire);
	}
	void Fire() {
		Debug.Log("FIRING In range");
		_time = 0;
		_laserTarget.Visible = false;
		_laserTarget.Width = 0;
	}
}
