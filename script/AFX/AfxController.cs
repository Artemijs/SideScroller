using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AFX_ID {
	FBALL_COLLIDED=0,
};
public class AfxController : MonoBehaviour
{
	public AudioSource[] _allSources;
    // Start is called before the first frame update
    void Start()
    {
		//_allSources[0].Play();
    }
	private void Update()
	{
	//	if(Input.GetKeyDown(KeyCode.A)) _allSources[0].Play();
	}

	public void PlayAFX(AFX_ID id) {
		_allSources[(int)(id)].Play();
	}
}
