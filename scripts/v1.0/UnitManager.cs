using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager
{
	private static UnitManager instance;

	List<Unit> _allUnits;
	private UnitManager()
	{
		_allUnits = new List<Unit>();
	}

	public void CalculateTotalStats() {
		foreach (Unit u in _allUnits) {
			u.StatMods.CalculateTotals();
		}
	}
	public int CreateUnit(GameObject go) {
		int id = _allUnits.Count;
		_allUnits.Add(new Unit(go));
		return id;
	}
	public Unit GetUnit(int id) {
		return _allUnits[id];
	}
	public static UnitManager Instance
	{
		get
		{
			if (instance == null)
			{
				instance = new UnitManager();
			}
			return instance;
		}
	}
	
}
