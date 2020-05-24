using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iAction {
	//protected bool _unlocked;
	//how many seconds this action goes on for
	//such as walking for 1 second to the left or blocking for 0.5
	protected float _duration;
	public virtual bool Execute (){
		
		_duration -= Time.deltaTime;
		if (_duration < 0)
		{
			return true;
		}
		else return false;
	}

}
