using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DmgTextAnim : MonoBehaviour
{
	public float _duration;
	float _time;
	Text _text;
	public static AnimationCurve _curve;
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
		c.a =  _curve.Evaluate(1-(_time / (_duration*0.5f))	);
		_text.gameObject.transform.position += new Vector3(0, 0.1f * _curve.Evaluate(_time / (_duration * 0.5f)), 0);
		_text.color = c;
		if (_time > _duration) {
				Destroy(gameObject);
			/*_time = 0;
			c.a = 1;
			_text.color = c;
			_text.gameObject.transform.position = Vector3.zero;*/
		}
    }
	public void SetText(string txt) {
		_text.text = txt;
	}
	public void SetCurve(AnimationCurve ac) {
		_curve = ac;
	}
}
