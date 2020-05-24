using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ComboLink
{
	public ComboLinkID _idName;
	public string _name;
	public float _length;
	public float _time;
	public float _hitTimeStart;
	public float _hitTimeEnd;
	float _speed;
	public ComboLink[] _allNextLinks;
	public ComboLink(ComboLinkID cId, string nam, float len, float time, float hitTime, float hitTimeOffset) {
		_name = nam;
		_length = len;
		_time = time;
		_hitTimeStart = hitTime;
		_hitTimeEnd = hitTime + hitTimeOffset;
		_idName = cId;
		_allNextLinks = null;
	}
	public string GetSerializedData() {
		string s = "";
		if(_allNextLinks != null)
			foreach (ComboLink cl in _allNextLinks) {
				s += cl._idName.ToString() + "|";
			}
		return  _idName.ToString() + "|" +
			_name + "|" + 
			_length.ToString() + "|" +
			_time.ToString() + "|" +
			_hitTimeStart.ToString() + "|" +
			_hitTimeEnd.ToString() + "|" + s;
			;
	}



}
