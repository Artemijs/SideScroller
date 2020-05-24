using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAction : iAction {
	int _unitId;
	public TestAction(int unitId, float time){
		base._duration = time;
		_unitId = unitId;
	}
	public override bool Execute(){
		Debug.Log("HAPPENS");
		Unit unit = UnitManager.Instance.GetUnit(_unitId);
		Rigidbody body = unit.GameOBJ.GetComponent<Rigidbody>();
		body.velocity = new Vector3(unit.StatMods.GetTotal(StatId.MOVE_SPEED), 0, 0);
		return base.Execute();
	}

}
