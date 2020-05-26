using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ComboLink
{
	public const int  max_branches = 2;
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
		_allNextLinks = new ComboLink[max_branches] { null, null };
	}
	public string GetSerializedData() {
		string s = "";
		for (int i = 0; i < max_branches; i++) {
			if (_allNextLinks[i] != null)
				s += _allNextLinks[i]._idName.ToString() + "|";
			else
				s += "END|";
		}
		s = _idName.ToString() + "|" +
			_name + "|" +
			_length.ToString() + "|" +
			_time.ToString() + "|" +
			_hitTimeStart.ToString() + "|" +
			_hitTimeEnd.ToString() + "|" + s;
		return s;
	}
	public string GetLenStr(string s) {
		int len = s.Length;
		string str = "";
		if (len < 100) {
			str = "0" + len.ToString();
		}
		if (len < 10)
		{
			str = "00" + len.ToString();

		}
		return str + s;
	}



}
