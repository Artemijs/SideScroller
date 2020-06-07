using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	Animator _animator;
	bool _playerDir;

	bool _inAir;

	// Start is called before the first frame update
	void Start()
	{
		_playerDir = true;
		_inAir = false;
		_animator = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{
		//gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
		float inptZ = Input.GetAxis("Horizontal");
		float inptY = Input.GetAxis("Vertical");
		CheckMousePos();
		if (inptZ != 0) {
			//Debug.Log("this too ");

		}
		if (inptY != 0 && ! _inAir) {
			_inAir = true;
			_animator.SetBool("inAir", _inAir);
			_animator.Play("Armed-Jump");
			
		}
		if (!_inAir)
		{
			_animator.SetFloat("inputZ", inptZ);
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

	private void OnCollisionEnter(Collision collision)
	{
		Vector3 colNorm = collision.GetContact(0).normal;
		if (colNorm.y > 0.85f) {
			_inAir = false;
			_animator.SetBool("inAir", _inAir);
		}
	}
}
