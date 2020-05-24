using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//ActionManager.Instance.AddAction(;
		ActionManager amgr = ActionManager.Instance;
		UnitManager u = UnitManager.Instance;
		//amgr.AddAction (new TestAction (gameObject, 2));
	}
	
	// Update is called once per frame
	void Update () {
		UnitManager.Instance.CalculateTotalStats();
		ActionManager.Instance.ExecuteUniqueActions();
		ActionManager.Instance.ExecuteActions ();
	}
}
