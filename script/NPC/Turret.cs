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
	CustomPlane _plane;
	TurretState _tState;
	public float _fireRate;
    // Start is called before the first frame update
    void Start()
    {
		_target = GameObject.Find("Player");
		CustomMeshController meshCtrl = GameObject.Find("Main").GetComponent<CustomMeshController>();
		_plane = meshCtrl.GetPlane();
		_plane.SetEndPoints(transform, _target.transform.GetChild(0));
	}

    // Update is called once per frame
    void Update()
    {

		if (_tState == TurretState.IDLE)
		{
			float range = GetRange();
			if (range > _maxRange) return;
			else if (_plane.Visible != true)
			{
				_plane.Visible = true;
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
			_plane.Visible = false;
			_time = 0;
		}
	}
	float GetRange() {
		return Vector3.Distance(_target.transform.position, transform.position);
	}
	void DrawBeam() {
		_plane.Update();
		_plane.Draw();
	}
	bool CheckFire() {
		_time += Time.deltaTime;
		
		return (_time > _time2Fire);
	}
	void Fire() {
		Debug.Log("FIRING In range");
		_time = 0;
		_plane.Visible = false;
	}
}
