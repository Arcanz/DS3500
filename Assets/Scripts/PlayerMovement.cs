using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	
	public float speed;
	public object inventory;
	
	private Vector3 defaultPosition;
	
	// Use this for initialization
	
	void Start () {
		
		defaultPosition= transform.position;
		
		float x = transform.position.x;
		if(PlayerPrefs.HasKey("PlayerPos_X"))
		{
			
		}
		
		float z = transform.position.z;
		if(PlayerPrefs.HasKey("PlayerPos_Z"))
		{
			
		}
		z = PlayerPrefs.GetFloat("PlayerPos_Z");
		transform.position = new Vector3(x, 1, z);
	}
	
	// Update is called once per frame
	void Update () 
	{
		//DEBUG! TODO: REmove this
		
	}
	
	
	void SavePos()
	{
		//Easy mode
		
		SaveLoadManager.instance.SavePref("PlayerPost_X", transform.position.x);
		SaveLoadManager.instance.SavePref("PlayerPost_Z", transform.position.z);
		//PlayerPrefs, settings etc
		//PlayerPrefs.SetFloat("PlayerPos_X", transform.position.x);
		//PlayerPrefs.SetFloat("PlayerPos_Y", transform.position.z);
		
		//Better mode
		
		
	}
}
