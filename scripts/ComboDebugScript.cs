using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class ComboDebugScript : MonoBehaviour
{
	ComboEditorScript _ces;
	ComboLink[] _combos;
	public bool _updateCombo;
	Animator _animator;
	void Start()
    {
		GameObject main = GameObject.Find("Main");
		_updateCombo = false;
		_ces = main.GetComponent<ComboEditorScript>();
		_combos = new ComboLink[3];
		_animator = GetComponent<Animator>();
		for (int i = 0; i < 3; i++) {
			_combos[i] = _ces.GetCombo(i);
		}
		_animator.SetFloat("animspeed", 1);
		//1.0f / Time.deltaTime * time ?
	}

    // Update is called once per frame
    void Update()
    {
		_animator.SetFloat("time", Time.deltaTime);
		if (_updateCombo) {
			for (int i = 0; i < 3; i++)
			{
				_combos[i] = _ces.GetCombo(i);
			}
			_updateCombo = false;
		}
		if (Input.GetMouseButtonDown(0)) {//light
			//play animation _combos[i]._name
			_animator.Play(_combos[0]._name);
		}
	}
	

}