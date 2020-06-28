using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : MonoBehaviour
{
	public GameObject _slashTemp;
	float _time;
	public float _timeBetweenStrikes;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		_time += Time.deltaTime;
		
    }
	public void Fire( Vector3 rotation) {
		if (_time < _timeBetweenStrikes) return;
		_time = 0;
		GameObject go = GameObject.Instantiate(_slashTemp, new Vector3(0, 1.5f, 0) + transform.position, Quaternion.identity);
		//rotation.z += Random.Range(-45, 45);
		go.transform.eulerAngles = rotation;
		if(rotation.y >= 270)
			go.GetComponent<Rigidbody>().velocity = new Vector3(-20, 0 ,0) ;
		else if (rotation.y > 0 &&  rotation.y < 270)
			go.GetComponent<Rigidbody>().velocity = new Vector3(20, 0, 0);

	}
}
