using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit
{
	StatMods _mods;
	GameObject _gameObject;
	public Unit(GameObject go) {
		_gameObject = go;
		_mods = new StatMods();
		_mods.AddStatModifier(StatId.DMG, 4);
		_mods.AddStatModifier(StatId.ENERGY_CURRENT, 10);
		_mods.AddStatModifier(StatId.ENERGY_MAX, 10);
		_mods.AddStatModifier(StatId.HP_CURRENT, 10);
		_mods.AddStatModifier(StatId.HP_MAX, 10);
		_mods.AddStatModifier(StatId.MOVE_SPEED, 10);
		_mods.AddStatModifier(StatId.JUMP_HEIGHT, 10);

	}
	public StatMods StatMods {
		get {
			return _mods;
		}
		set { _mods = value; }
	}
	public GameObject GameOBJ {
		get { return _gameObject; }
		set { _gameObject = value; }
	}
}
