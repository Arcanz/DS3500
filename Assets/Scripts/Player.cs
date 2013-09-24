using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	public SpaceGui gui;
	public GameObject fireball;
	
	public float clickDelay = 0.5f;
	private float lastClick = 0;
	// Use this for initialization
	
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		shoot ();
	
	}

	void shoot ()
	{
		if(lastClick <= 0)
		{
			if(Input.GetAxis("Fire1")!=0)
			{
				Vector2 mPos = Input.mousePosition;
				mPos.y = Camera.main.pixelHeight - mPos.y;
				
				if(!gui.IsOverGui(mPos))
				{
					lastClick = clickDelay;
					GameObject f = (GameObject)Instantiate(fireball);
					f.transform.position = this.transform.position;
				}
			}
		}
		if(lastClick > 0)
		{
			lastClick -= Time.deltaTime;
		}
	}
}
