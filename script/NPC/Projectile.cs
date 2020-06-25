using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	public GameObject _target;
	public float _speed;
	public static Main _main;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		transform.position += (_target.transform.position - transform.position).normalized * _speed * Time.deltaTime;
		transform.LookAt(_target.transform.position);
    }
	private void OnTriggerEnter(Collider other)
	{
		//Debug.Log(other.gameObject.name);
		if (other.gameObject.name == "Player")
		{
			GetComponent<AudioSource>().mute = true;
			_main.PlayerTakeDamage(gameObject);
			Destroy(gameObject);
			/*
			
			GetComponent<AudioSource>().mute = true;
			transform.position = new Vector3(Random.Range(-25, 25), Random.Range(-25, 25), 0);*/

		}
		//gameObject.SetActive(false);
	}
	
}
