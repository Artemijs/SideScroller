using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UniqueActionID {
	JUMP=0,
	MOVE
};
public struct ActionData {
	public UniqueActionID _id;
	public int[] _args;
};
public class ActionManager
{
	private List<iUniqueAction> _allUniActions;
	private List<ActionData> _allUActionData;
	private List<iAction> _allActions;

	private static ActionManager instance;

	private ActionManager() {
		_allUniActions = new List<iUniqueAction>();
		_allActions = new List<iAction> ();
		_allUActionData = new List<ActionData>();
		//populate the array with default values so that i cant use _allUniActions[(int)UniqueActionID.MOVE] without worrying about add order
		for (int i = 0; i < (int)UniqueActionID.MOVE+1; i++) {
			_allUniActions.Add(null);
		}
		_allUniActions[(int)UniqueActionID.MOVE] = new A_Move();
		_allUniActions[(int)UniqueActionID.JUMP] = new A_Jump();
	}
	public void AddUniqueAction(ActionData ad) {
		_allUActionData.Add(ad);
	}
	public void AddAction(iAction action){
		_allActions.Add (action);
		
	}
	public void ExecuteUniqueActions() {
		ActionData ad;
		for (int i = 0; i < _allUActionData.Count; i++) {
			ad = _allUActionData[i];
			_allUniActions[(int)ad._id].Execute(ref ad._args);
		}
		_allUActionData.Clear();
	}
	public void ExecuteActions(){

		List<int> toRemove = new List<int>();
		//Debug.Log("executing action " + _allActions.Count);
		for (int i = 0; i < _allActions.Count; i++) {
			if (_allActions[i].Execute())
				toRemove.Add(i);
		}
		if(toRemove.Count !=0)
			ClearActions(ref toRemove);
	}
	public void ClearActions (ref List<int> toRemove){
		Debug.Log("REMOVING " + toRemove.Count);
		for (int i = 0; i < toRemove.Count; i++) {
			_allActions.RemoveAt(toRemove[i]);
		}
	}
	public static ActionManager Instance
	{
		get{
			if(instance == null){
				instance = new ActionManager();
			}
			return instance;
		}
	}
}