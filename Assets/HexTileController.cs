using UnityEngine;
using System.Collections;

public class HexTileController : MonoBehaviour 
{
	private Color originalColor;
	private Color hooverColor;
	private Color clickColor;
	//private Vector3 oldPosition;
	//private Vector3 selectedPosition;
	
	void Start()
	{
		originalColor = renderer.material.color;
		hooverColor = Color.cyan;
		clickColor = Color.red;
		//selectedPosition = new Vector3 (transform.position.x, transform.position.y+1, transform.position.z);
		//oldPosition = transform.position;
	}
	void OnMouseEnter()
	{
		gameObject.renderer.material.color = hooverColor;
		//transform.position = selectedPosition;
	}
	void OnMouseExit()
	{
		gameObject.renderer.material.color = originalColor;
		//transform.position = oldPosition;
	}
	void OnMouseDown()
	{
		gameObject.renderer.material.color = clickColor;
		//TODO: Make the magic happen	
	}
	void OnMouseUp()
	{
		OnMouseEnter();
	}
}
