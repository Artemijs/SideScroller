using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
	VfxController _vfxCtrl;
	AfxController _afxCtrl;
	public Transform _player;
	private void Awake()
	{
		//init statics
		Projectile._main = this;
	}
	// Start is called before the first frame update
	void Start()
    {
		_vfxCtrl = GetComponent<VfxController>();
		_vfxCtrl.PlayVfxText(VFXTEXT_ID.DMG_TEXT, _player.GetChild(0).position, "-" + Random.Range(90, 100).ToString());
		_afxCtrl = GetComponent<AfxController>();

	}

    // Update is called once per frame
    void Update()
    {
        
    }

	public void PlayerTakeDamage(GameObject obj) {
		int dmg = Random.Range(90, 100);
		if (_player.gameObject.GetComponent<PlayerController>().Blocking) dmg = 0;

		_afxCtrl.PlayAFX(AFX_ID.FBALL_COLLIDED);
		//play onhit particles
		_vfxCtrl.PlayVfxRotatedLookAT(VFX_ID.ON_HIT, _player.GetChild(0).position, obj.transform.position);
		//-100 dmg red letters
		_vfxCtrl.PlayVfxText(VFXTEXT_ID.DMG_TEXT, _player.GetChild(0).position, "-"+ dmg.ToString());
		//play sound
		
	}
}
