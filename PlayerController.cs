using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	Animator _animator;
	bool _playerDir;
	PhysicsObject _phyo;
	public float _jumpSpeed;
	// Start is called before the first frame update
	void Start()
	{
		_playerDir = true;

		_animator = GetComponent<Animator>();
		_phyo = GetComponent<PhysicsObject>();
	}

	// Update is called once per frame
	void Update()
	{
		//gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
		float inptZ = Input.GetAxis("Horizontal");
		float inptY = Input.GetAxis("Vertical");
		CheckMousePos();
		if (inptZ != 0) {
			_animator.SetFloat("inputZ", inptZ);
			Move(inptZ);

		}
		if (inptY != 0 && !_phyo.InAir) {
			//_phyo.InAir = true;
			_animator.SetBool("inAir", _phyo.InAir);
			_animator.Play("Armed-Jump");
			//dir2Cursor*jumpspeed
			//_phyo.AddAirForce(Dir2Cursor() * _jumpSpeed);
			_phyo.AddAirForce(new Vector3(0, _jumpSpeed, 0));
			
		}
		
		
		if (Input.GetAxis("Jump") != 0) {
			//_animator.Play("Armed-Jump");			
			//Roll(inptZ);
		}
		if (CheckBlock())
			Roll(inptZ);
		CheckAttack();


	}
	void CheckAttack() {
	

			
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
			_animator.SetBool("blocking", true);
		}
		if (Input.GetMouseButtonUp(1))
		{
			_animator.SetBool("blocking", false);
		}
		return (Input.GetMouseButton(1));
	}
	public void FootR() {
		
	}
	public void FootL() { }

	public void Land() { }
	private void Move(float inptz)
	{
		float speed = 7.5f;
		_phyo.AddVelocity(new Vector3(inptz* speed, 0, 0));
	}
	Vector3 Dir2Cursor() {
		Vector3 dir = Vector3.zero;
		dir = (  Input.mousePosition - new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0)).normalized;
		return dir;
	}
}
