using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
	public GameObject _target;
	public float _speed;

    // Start is called before the first frame update
    void Start()
    {

	}

    // Update is called once per frame
    void Update()
    {
		//float dist = Vector3.Distance(transform.position, _target.transform.position);
		Vector3 mPos = new Vector3(transform.position.x,  transform.position.y, 0);
		Vector3 tPos = new Vector3(_target.transform.position.x, _target.transform.position.y , 0);
		float dist = Vector2.Distance(mPos, tPos);
		Vector3 dir = (tPos - mPos).normalized;
		transform.position += dir * Time.deltaTime * _speed * GetSpeedOffset(dist);

	}
	float GetSpeedOffset(float dist) {
		float dist2end = dist/(Screen.width * 0.5f);
		if (dist2end > 1) dist2end = 1;
		else if (dist2end < 0) dist2end = 0;

		return dist2end;
	}
}
