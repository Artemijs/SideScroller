using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
	public GameObject _target;
	public float _speed;
	public float _mouseOffsetSpeed;
	public Vector2 _offset;
	Vector2 _halfScreen;
    // Start is called before the first frame update
    void Start()
    {
		_halfScreen = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);
	}

    // Update is called once per frame
    void Update()
    {
		//float dist = Vector3.Distance(transform.position, _target.transform.position);
		Vector3 mPos = new Vector3(transform.position.x, transform.position.y, 0);
		
		Vector3 tPos = new Vector3(_target.transform.position.x, _target.transform.position.y , 0);
		float dist = Vector2.Distance(mPos, tPos);
		Vector3 dir = (tPos - mPos).normalized;
		transform.position += dir * Time.deltaTime * _speed * GetSpeedOffset(dist);
		MouseOffset();
	}

	void MouseOffset() {
		Vector2 mPos = Input.mousePosition;
		Vector3 result = Vector3.zero;
		if (mPos.x > _halfScreen.x)
		{
			result.x = (mPos.x - _halfScreen.x) / _halfScreen.x;
		}
		else {
			result.x = -((_halfScreen.x - mPos.x ) / _halfScreen.x);
		}
		if (mPos.y > _halfScreen.y)
		{
			result.y = (mPos.y - _halfScreen.y) / _halfScreen.y;
		}
		else
		{
			result.y = -((_halfScreen.y - mPos.y) / _halfScreen.y);
		}
		if (result.x > 1) result.x = 1;
		else if (result.x < -1) result.x = -1;
		result.z = 0;
		//result.y = 0;
		transform.GetChild(0).localPosition = (result * _mouseOffsetSpeed) +  new Vector3(_offset.x, _offset.y, 0);
	}
	float GetSpeedOffset(float dist) {
		float dist2end = dist/(_halfScreen.x);
		if (dist2end > 1) dist2end = 1;
		else if (dist2end < 0) dist2end = 0;

		return dist2end;
	}
}
