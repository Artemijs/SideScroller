using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public struct AttackAnimData {
	public string _name;
	public float _length;
	public float _time;
	public float _speed;
	public float _exitTime;
};
public class ComboData : MonoBehaviour {
	public string[] animationNames;
	public float[] animationTimes;
	public float[] exitTimes;
	public float transition_percent;
	AttackAnimData[] _allData;
    void Start()
    {
		int len = animationNames.Length;
		_allData = new AttackAnimData[len];
		Animator anim = GetComponent<Animator>();
		foreach (AnimationClip clip in anim.runtimeAnimatorController.animationClips) {
			
			for (int i =0; i < len; i++) {
				if (clip.name == animationNames[i]) {
					clip.events = new AnimationEvent[0];
					AttackAnimData aad = new AttackAnimData();
					//pFrameData[i].w = clip.length;
					aad._length = clip.length;
					print("ANIMATION TIME " + clip.length);
					aad._name = clip.name;
					aad._exitTime = exitTimes[i];
					aad._time = animationTimes[i];
					aad._speed = getClipTime(aad._length, aad._time * (1 + transition_percent));
					_allData[i] = aad;
					

				}
			}
		}

	}
	float getClipTime(float len, float newLen) {
		//return len+(newLen*(1-(len/newLen)));
		//return newLen;//len/ newLen;
		float fr = 30;

		return (fr * len) / (fr * newLen);
	}
    // Update is called once per frame
    void Update()
    {
        
    }
	public AttackAnimData GetAAD(int index) { return _allData[index]; }
}
