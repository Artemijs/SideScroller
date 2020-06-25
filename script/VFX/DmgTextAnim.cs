using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DmgTextAnim : MonoBehaviour
{
	public float _duration;
	float _time;
	Text _text;
    // Start is called before the first frame update
    void Start()
    {
		Init();

	}
	public void Init()
	{
		_text = GetComponent<Text>();
	}
	// Update is called once per frame
	void Update()
    {
		_time += Time.deltaTime;
		Color c = _text.color;
		c.a = 1-(_time/_duration);
		_text.gameObject.transform.position += new Vector3(0, 0.025f, 0);
		_text.color = c;
		if (_time > _duration) {
			Destroy(gameObject);
		}
    }
	public void SetText(string txt) {
		_text.text = txt;
	}
}
