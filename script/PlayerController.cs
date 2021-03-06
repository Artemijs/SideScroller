﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	Animator _animator;
	bool _playerDir;
	PhysicsObject _phyo;
	public float _jumpSpeed;
	public bool _rolling;
	bool _blocking;
	Slash _slash;
	// Start is called before the first frame update
	void Start()
	{
		_slash = GetComponent<Slash>();
		_playerDir = true;
		_rolling = false;
		_animator = GetComponent<Animator>();
		_phyo = GetComponent<PhysicsObject>();
	}

	// Update is called once per frame
	void Update()
	{
		//gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
		/*float inptZ = Input.GetAxis("Horizontal");
		if (inptZ != 0) {
			if (inptZ > 0) inptZ = 1;
			else inptZ = -1;
		}*/
		float inptZ = 0;
		if (Input.GetKey(KeyCode.A)) inptZ = -1;
		else if (Input.GetKey(KeyCode.D)) inptZ = 1;
		float inptY = Input.GetAxis("Vertical");
		_animator.SetFloat("inputZ", inptZ);
		CheckMousePos();
		if (inptZ != 0) {
			Move(inptZ);

		}
		if (inptY != 0 && !_phyo.InAir) {
			//_phyo.InAir = true;
			_animator.SetBool("inAir", _phyo.InAir);
			_animator.Play("Armed-Jump");
			//dir2Cursor*jumpspeed
			//_phyo.AddAirForce(Dir2Cursor() * _jumpSpeed);
			_phyo.AddAirForce(new Vector3(inptZ * 2, _jumpSpeed, 0));
			
		}
		
		
		if (Input.GetAxis("Jump") != 0) {
			//_animator.Play("Armed-Jump");
			//Roll(inptZ);
		}
		CheckBlock();
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Roll(inptZ);
		}
		CheckAttack();
		if (_rolling) {
			_phyo.AddVelocity(new Vector3(inptZ * 30, 0, 0));
		}

	}
	void CheckAttack() {

		if(Input.GetMouseButtonDown(0))
			_slash.Fire(transform.eulerAngles);
			
			//float animTime =  _animator.GetCurrentAnimatorStateInfo(0).normalizedTime;

			//print(animTime+ " "+ caad._time);
			
			/*if (animTime >= _caad._time) {
				_currentAttack = 0;
				print("finished attacking ");
			}*/
			

	}
	void Roll(float inptX)
	{
		if (_playerDir)
		{
			if (inptX > 0)
			{
				_animator.Play("Armed-Roll-Forward");
			}
			else if (inptX < 0)
			{
				_animator.Play("Armed-Roll-Backward");
			}
		}
		else
		{
			if (inptX > 0)
			{
				_animator.Play("Armed-Roll-Backward");
			}
			else if (inptX < 0)
			{
				_animator.Play("Armed-Roll-Forward");
			}
		}
	}
	void CheckMousePos() {
		_playerDir = (Input.mousePosition.x >= Screen.width / 2);
		TurnPlayer();
	}
	void TurnPlayer() {
		if (_playerDir)
		{
			gameObject.transform.rotation = Quaternion.Euler(0, 90, 0);
			_animator.SetFloat("inputDir", -1);
		}
		else
		{
			gameObject.transform.rotation = Quaternion.Euler(0, -90, 0);
			_animator.SetFloat("inputDir", 1);
		}
	}
	bool CheckBlock() {
		if (Input.GetMouseButtonDown(1)) {
			_blocking = true;
			_animator.SetBool("blocking", true);
		}
		if (Input.GetMouseButtonUp(1))
		{
			_blocking = false;
			_animator.SetBool("blocking", false);
		}
		return (Input.GetMouseButton(1));
	}
	public void FootR() { }
	public void FootL() { }

	public void Land() { }

	public void start_roll() {
		_rolling = true;
	}
	public void end_roll() {
		_rolling = false;
	}
	private void Move(float inptz)
	{
		float speed = 7.5f;
		if (Input.GetMouseButton(1)) {
			speed *= 0.5f;
		}
		_phyo.AddVelocity(new Vector3(inptz* speed, 0, 0));
	}
	Vector3 Dir2Cursor() {
		Vector3 dir = Vector3.zero;
		dir = (  Input.mousePosition - new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0)).normalized;
		return dir;
	}
	public bool Blocking { get { return _blocking; }set { _blocking = false; } }

	private void OnTriggerEnter(Collider other)
	{
		//Debug.Log(other.gameObject.name);
		if (other.gameObject.tag == "Projectile")
		{
			//GetComponent<AudioSource>().mute = true;
			//_main.PlayerTakeDamage(gameObject);
			if (_blocking)
			{
				Projectile p = other.gameObject.GetComponent<Projectile>();
				Vector2 mPos = Input.mousePosition;
				Vector2 dir = (mPos - new Vector2(Screen.width * 0.5f, Screen.height * 0.5f)).normalized;
				p.Rebound(dir);
			}
			else
			{
				Destroy(other.gameObject);
			}
			/*
			
			GetComponent<AudioSource>().mute = true;
			transform.position = new Vector3(Random.Range(-25, 25), Random.Range(-25, 25), 0);*/

		}
		//gameObject.SetActive(false);
	}
}
