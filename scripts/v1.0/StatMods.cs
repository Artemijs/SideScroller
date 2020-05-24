using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatId {
	HP_MAX = 0,
	HP_CURRENT,
	ENERGY_MAX,
	ENERGY_CURRENT,
	MOVE_SPEED,
	JUMP_HEIGHT,
	BLOCK,
	DMG
};

public class StatMods
{
	List<List<float>> _allStats;
	float[] _allTotals;
	public StatMods() {
		_allStats = new List<List<float>>();
		//hp max
		_allStats.Add(new List<float>());
		//hp current
		_allStats.Add(new List<float>());
		//energy max
		_allStats.Add(new List< float>());
		//energy current
		_allStats.Add(new List<float>());
		//move speed
		_allStats.Add(new List<float>());
		//jumpheight
		_allStats.Add(new List<float>());
		//block
		_allStats.Add(new List<float>());
		//dmg
		_allStats.Add(new List< float>());

		_allTotals = new float[(int)StatId.DMG+1];
	}

	public void CalculateTotals() {
		for (int i = 0; i < _allStats.Count; i++) {
			_allTotals[i] = 0;
			foreach (var val in _allStats[i]) {
				_allTotals[i] += val;
			}
		}
	}
	public int AddStatModifier(StatId statId, float val) {
		int id = _allStats[(int)statId].Count;
		_allStats[(int)statId].Add(val);
		return id;
	}
	public void RemoveStatModifier(StatId statId, int valId)
	{
		_allStats[(int)statId].RemoveAt(valId);
	}
	public float GetTotal(StatId stat) {
		return _allTotals[(int)stat];
	}
}


