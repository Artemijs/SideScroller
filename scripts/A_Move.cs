using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_Move : iUniqueAction
{
	public A_Move() { }
	/// <summary>
	/// args[0] = unit id \n
	/// args[1] = direction 1, -1
	/// </summary>
	/// <param name="args"></param>
	public override void Execute(ref int[] args)
	{
		//Debug.Log("HAPPENS");
		Unit unit = UnitManager.Instance.GetUnit(args[0]);
		Rigidbody body = unit.GameOBJ.GetComponent<Rigidbody>();
		body.velocity += new Vector3(unit.StatMods.GetTotal(StatId.MOVE_SPEED) * (float)(args[1])*0.01f, 0, 0);
	}
}
