using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
public enum ComboLinkID {
	M1 = 0,
	M2,
	M3,
	END
};
public class ComboDebugScript : MonoBehaviour
{
	ComboLink[] _allComboMoves;
	public ComboLinkID _CurrentlySelectedLink;
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
	public bool _load2file = false;
	void Awake()
    {
		LoadMoves();

	}

    // Update is called once per frame
    void Update()
    {
		if (_save) {
			Save();
			_save = false;
		}
		if (_load) {
			Load();
			_load = false;
		}
		if (_save2file)
		{
			SaveFile();
			_save2file = false;
		}
		if (_load2file)
		{
			LoadFile();
			_load2file = false;
		}
	}
	private void Load() {
		_length =_allComboMoves[(int)_CurrentlySelectedLink]._length;
		_name = _allComboMoves[(int)_CurrentlySelectedLink]._name;
		_hitTimeEnd = _allComboMoves[(int)_CurrentlySelectedLink]._hitTimeEnd;
		_hitTimeStart = _allComboMoves[(int)_CurrentlySelectedLink]._hitTimeStart;
		_time = _allComboMoves[(int)_CurrentlySelectedLink]._time;

	}
	private void Save() {
		_allComboMoves[(int)_CurrentlySelectedLink]._length = _length;
		_allComboMoves[(int)_CurrentlySelectedLink]._name = _name;
		_allComboMoves[(int)_CurrentlySelectedLink]._hitTimeEnd = _hitTimeEnd;
		_allComboMoves[(int)_CurrentlySelectedLink]._hitTimeStart = _hitTimeStart;
		_allComboMoves[(int)_CurrentlySelectedLink]._time = _time;


	}
	private void LoadMoves() {
		_allComboMoves = new ComboLink[(int)ComboLinkID.END];
		for (int i = 0; i < _allComboMoves.Length; i++) {
			_allComboMoves[i] = new ComboLink((ComboLinkID)(i), "temp", 0,0,0,0);
		}
		LoadFile();
	}

	public void SaveFile()
	{
		string fPath = Application.persistentDataPath + "/combos.txt";
		if (File.Exists(fPath)) {
			File.Delete(fPath);
		}

		FileStream fs = new FileStream(fPath, FileMode.CreateNew);
		string data = "";

		foreach (ComboLink cl in _allComboMoves) {
			data += cl.GetSerializedData();
		}
		byte[] bytes = Encoding.UTF8.GetBytes(data);
		fs.Write(bytes, 0, bytes.Length);
		fs.Close();

	}

	public void LoadFile()
	{
		//M1|temp|0|0|0|0|M2|temp|0|0|0|0|M3|temp|0|0|0|0|
		string fPath = Application.persistentDataPath + "/combos.txt";

		if (!File.Exists(fPath))
		{
			return;
		}
		string allData = "";
		FileStream fs = new FileStream(fPath, FileMode.Open);
		byte[] buf = new byte[1024];
		int c;

		while ((c = fs.Read(buf, 0, buf.Length)) > 0)
		{
			allData += Encoding.UTF8.GetString(buf, 0, c);
		}
		fs.Close();
		Debug.Log(allData);
		string[] allDataSplit = allData.Split('|');
		int ind = 0;
		for (int i = 0; i < allDataSplit.Length-1; i+=6) {
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

}