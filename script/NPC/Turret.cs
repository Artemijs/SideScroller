using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
	GameObject _target;
	public  float _maxRange;
	float _time = 0;
	public  float _time2Fire;
	CustomPlane _plane;
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
		float range = GetRange();
		if (range > _maxRange) return;
		else if(_plane.Visible != true) {
			_plane.Visible = true;
			
		}
		Debug.Log("In range");
		DrawBeam();
		/*bool t2Fire = CheckFire();
		if (!t2Fire) return;
		Fire();*/
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
		Debug.Log("not In range");
		_time = 0;
		_plane.Visible = false;
	}
}
