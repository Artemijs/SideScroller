using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	Animator _animator;
	bool _playerDir;
	int _currentAttack;
	ComboData _comboData;
	int _unitId;
	bool _inAir;
	float _time;
	AttackAnimData _caad;
	
	// Start is called before the first frame update
	void Start()
	{
		_time = 0;
		_playerDir = true;
		_inAir = false;
		_currentAttack = 0;
		_animator = GetComponent<Animator>();
		_comboData = GetComponent<ComboData>();
		_unitId = UnitManager.Instance.CreateUnit(gameObject);
		
	}

	// Update is called once per frame
	void Update()
	{
		//gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
		float inptX = Input.GetAxis("Horizontal");
		float inptY = Input.GetAxis("Vertical");
		CheckMousePos();
		if (inptX != 0) {
			//Debug.Log("this too ");
			//ActionManager.Instance.AddAction(new TestAction(_unitId, 0.5f));
			ActionManager.Instance.AddUniqueAction(new ActionData() { _id = UniqueActionID.MOVE, _args = new int[] { _unitId, (int)(inptX*10) } });
		}
		if (inptY != 0 && ! _inAir) {
			_inAir = true;
			_animator.SetBool("inAir", _inAir);
			_animator.Play("Armed-Jump");
			ActionManager.Instance.AddUniqueAction(new ActionData() { _id = UniqueActionID.JUMP, _args = new int[] { _unitId } });
		}
		if (!_inAir)
		{
			_animator.SetFloat("inputZ", inptX);
		}
		
		if (Input.GetAxis("Jump") != 0) {
			//_animator.Play("Armed-Jump");			
			Roll(inptX);
		}
		CheckBlock();
		CheckAttack();


	}
	void CheckAttack() {
		
		if (Input.GetMouseButtonDown(0) && _currentAttack == 0)
		{
			_caad = _comboData.GetAAD(0);
			_currentAttack++;
			_animator.Play(_caad._name, 0, 0);
			
		}
		else if (_currentAttack != 0)
		{

			
			float animTime = _caad._time * _animator.GetCurrentAnimatorStateInfo(0).normalizedTime;

			//print(animTime+ " "+ caad._time);
			
			if (animTime >= _caad._time) {
				_currentAttack = 0;
				print("finished attacking ");
			}
			
		}
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
			_animator.SetFloat("inputDir", 0);
		}
		else
		{
			gameObject.transform.rotation = Quaternion.Euler(0, -90, 0);
			_animator.SetFloat("inputDir", 1);
		}
	}
	void CheckBlock() {
		if (Input.GetMouseButtonDown(1)) {
			_animator.SetBool("blocking", true);
		}
		if (Input.GetMouseButtonUp(1))
		{
			_animator.SetBool("blocking", false);
		}
	}
	public void FootR() { }
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
