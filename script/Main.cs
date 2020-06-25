using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
	VfxController _vfxCtrl;
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

	}

    // Update is called once per frame
    void Update()
    {
        
    }

	public void PlayerTakeDamage(GameObject obj) {
		//play onhit particles
		_vfxCtrl.PlayVfxRotated(VFX_ID.ON_HIT, _player.GetChild(0).position, obj.transform.position);
		//-100 dmg red letters
		_vfxCtrl.PlayVfxText(VFXTEXT_ID.DMG_TEXT, _player.GetChild(0).position, "-"+Random.Range(90,100).ToString());
		//play sound
	}
}
