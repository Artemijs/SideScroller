using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum VFX_ID {
	ON_HIT=0
};
public enum VFXTEXT_ID
{
	DMG_TEXT = 0,
};
public class VfxController : MonoBehaviour
{
	public GameObject _canvas;
	public GameObject[] _allVfxs;
	public GameObject[] _allVfxTexts;
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	public void PlayVfxText(VFXTEXT_ID id, Vector3 pos, string txt)
	{
		pos.z -= 1;
		GameObject go = GameObject.Instantiate(_allVfxTexts[(int)(id)], pos, Quaternion.identity, _canvas.transform);
		go.GetComponent<DmgTextAnim>().Init();
		go.GetComponent<DmgTextAnim>().SetText(txt);
	}
	public void PlayVfx(VFX_ID id, Vector3 pos) {

		GameObject.Instantiate(_allVfxs[(int)(id)], pos, Quaternion.identity);
	}
	public void PlayVfxRotated(VFX_ID id, Vector3 pos, Vector3 rot2Pos)
	{

		GameObject go = GameObject.Instantiate(_allVfxs[(int)(id)], pos, Quaternion.identity);
		go.transform.LookAt(rot2Pos);
		//GameObject.Instantiate(_allVfxs[(int)(id)], pos, Quaternion.identity);
	}
}
