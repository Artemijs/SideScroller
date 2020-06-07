using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
public enum ComboLinkID
{
	M1 = 0,
	M2,
	M3,
	M4,
	M5,
	M6,
	M7,
	M8,
	M9,
	END
};
public class ComboEditorScript : MonoBehaviour
{
	ComboLink[] _allComboMoves;
	public ComboLinkID _CurrentlySelectedLink;
	ComboLinkID _lastSelected;
	public string _name;
	public float _length;
	public float _time;
	public float _hitTimeStart;
	public float _hitTimeEnd;
	float _speed;
	public ComboLinkID[] _allNextLinks;
	public bool _save = false;
	public bool _load = false;
	public bool _save2file = false;
	public bool _loadFromfile = false;
	void Awake()
	{
		LoadMoves();
	}

	// Update is called once per frame
	void Update()
	{
		if (_CurrentlySelectedLink == ComboLinkID.END)
		{
			_CurrentlySelectedLink = ComboLinkID.M1;
			//Load();
		}
		if (_CurrentlySelectedLink != _lastSelected)
		{
			Save(_lastSelected);
			Load();
			_lastSelected = _CurrentlySelectedLink;
		}
		
		if (_save)
		{
			Save(_CurrentlySelectedLink);
			_save = false;
		}
		if (_load)
		{
			Load();
			_load = false;
		}
		if (_save2file)
		{
			SaveFile();
			_save2file = false;
		}
		if (_loadFromfile)
		{
			LoadFile();
			Load();
			_loadFromfile = false;
		}
	}
	private void Load()
	{
		_length = _allComboMoves[(int)_CurrentlySelectedLink]._length;
		_name = _allComboMoves[(int)_CurrentlySelectedLink]._name;
		_hitTimeEnd = _allComboMoves[(int)_CurrentlySelectedLink]._hitTimeEnd;
		_hitTimeStart = _allComboMoves[(int)_CurrentlySelectedLink]._hitTimeStart;
		_time = _allComboMoves[(int)_CurrentlySelectedLink]._time;

		_allNextLinks = new ComboLinkID[_allComboMoves[(int)_CurrentlySelectedLink]._allNextLinks.Length];
		int i = 0;
		foreach (ComboLink cl in _allComboMoves[(int)_CurrentlySelectedLink]._allNextLinks)
		{
			if (cl != null)
				_allNextLinks[i] = cl._idName;
			else
				_allNextLinks[i] = ComboLinkID.END;
			i++;
		}
	}
	private void Save(ComboLinkID clid)
	{
		if (!CheckEdit()) return;
		_allComboMoves[(int)clid]._length = _length;
		_allComboMoves[(int)clid]._name = _name;
		_allComboMoves[(int)clid]._hitTimeEnd = _hitTimeEnd;
		_allComboMoves[(int)clid]._hitTimeStart = _hitTimeStart;
		_allComboMoves[(int)clid]._time = _time;

		//_allComboMoves[(int)clid]._allNextLinks = new ComboLink[_allNextLinks.Length];
		for (int i = 0; i < _allNextLinks.Length; i++)
		{
			if (_allNextLinks[i] == ComboLinkID.END)
			{
				_allComboMoves[(int)clid]._allNextLinks[i] = null;
			}
			else
				_allComboMoves[(int)clid]._allNextLinks[i] = _allComboMoves[(int)(_allNextLinks[i])];
		}


	}
	private bool CheckEdit()
	{
		int change = 0;
		if (_allComboMoves[(int)_CurrentlySelectedLink]._length != _length)
		{
			change++;
		}
		if (_allComboMoves[(int)_CurrentlySelectedLink]._name != _name)
		{
			change++;
		}
		if (_allComboMoves[(int)_CurrentlySelectedLink]._hitTimeEnd != _hitTimeEnd)
		{
			change++;
		}
		if (_allComboMoves[(int)_CurrentlySelectedLink]._hitTimeStart != _hitTimeStart)
		{
			change++;
		}
		if (_allComboMoves[(int)_CurrentlySelectedLink]._time != _time)
		{
			change++;
		}
		if (_allComboMoves[(int)_CurrentlySelectedLink]._allNextLinks.Length != _allNextLinks.Length)
		{
			change++;
			return (change != 0);
		}
		for (int i = 0; i < _allNextLinks.Length; i++)
		{
			if (_allComboMoves[(int)_CurrentlySelectedLink]._allNextLinks[i] == null && _allNextLinks[i] != ComboLinkID.END)
			{
				change++;
			}
			else if (_allComboMoves[(int)_CurrentlySelectedLink]._allNextLinks[i] == null && _allNextLinks[i] == ComboLinkID.END)
			{
				continue;
			}
			else if (_allComboMoves[(int)_CurrentlySelectedLink]._allNextLinks[i]._idName != _allNextLinks[i])
			{
				change++;
			}
		}
		return (change != 0);
	}
	private void LoadMoves()
	{
		_allComboMoves = new ComboLink[(int)ComboLinkID.END];
		for (int i = 0; i < _allComboMoves.Length; i++)
		{
			_allComboMoves[i] = new ComboLink((ComboLinkID)(i), "temp", 0, 0, 0, 0);
		}
		LoadFile();
	}

	public void SaveFile()
	{
		/*	string path = Path.GetFullPath("Assets/test.txt");
			//if (!File.Exists(path))
			//{
				var fs = new FileStream(path, FileMode.Create);
				fs.Dispose();
				string text = File.ReadAllText(path);
				Debug.Log(text);
			//}*/
		//Read the text from directly from the test.txt file
		/*StreamReader reader = new StreamReader(path);
		Debug.Log(reader.ReadToEnd());
		reader.Close();
		*/

		string path = Path.GetFullPath("Assets/ComboData/combo.ext");
		Debug.Log(path);
		FileStream fs = new FileStream(path, FileMode.Truncate);

		string data = "";
		foreach (ComboLink cl in _allComboMoves)
		{
			data += cl.GetSerializedData();
		}
		Debug.Log(data);
		byte[] bytes = Encoding.UTF8.GetBytes(data);
		fs.Write(bytes, 0, bytes.Length);
		fs.Close();
		fs.Dispose();



		  
	}

	public void LoadFile()
	{

		//M1|temp|0|0|0|0|M2|temp|0|0|0|0|M3|temp|0|0|0|0|
		string path = Path.GetFullPath("Assets/ComboData/combo.ext");
		Debug.Log(path);
		if (!File.Exists(path))
		{
			return;
		}
		string allData = "";
		FileStream fs = new FileStream(path, FileMode.Open);
		byte[] buf = new byte[1024];
		int c;

		while ((c = fs.Read(buf, 0, buf.Length)) > 0)
		{
			allData += Encoding.UTF8.GetString(buf, 0, c);
		}
		fs.Close();
		fs.Dispose();
		Debug.Log(allData);

		string[] allDataSplit = allData.Split('|');
		int ind = 0;
		int itmsPerObj = ComboLink.max_branches + 5;
		for (int i = 0; i < allDataSplit.Length - 1; i += itmsPerObj + 1)
		{
			ComboLink cl = new ComboLink((ComboLinkID)Enum.Parse(typeof(ComboLinkID), allDataSplit[i]),
				(allDataSplit[i + 1]),
				float.Parse(allDataSplit[i + 2]),
				float.Parse(allDataSplit[i + 3]),
				float.Parse(allDataSplit[i + 4]),
				float.Parse(allDataSplit[i + 5])
				);
			_allComboMoves[ind] = cl;
			ind++;

		}


	}
	public ComboLink GetCombo(int id) {
		id = id % 3;
		return _allComboMoves[id];
	}

}