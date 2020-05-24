using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_Jump : iUniqueAction
{
	public A_Jump() { }

	/// <summary>
	/// args[0] = unitId that is jumping
	/// </summary>
	/// <param name="args"></param>
	public override void Execute(ref int[] args)
	{
		Debug.Log("jumping");
		Unit u = UnitManager.Instance.GetUnit(args[0]);
		Rigidbody body = u.GameOBJ.GetComponent<Rigidbody>();
		Vector3 v = body.velocity;
		v.y = u.StatMods.GetTotal(StatId.JUMP_HEIGHT);
		body.velocity = v;
	}
}
