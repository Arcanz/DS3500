using UnityEngine;
using System.Collections;

public class HexGrid : MonoBehaviour {

	public GameObject hexTile;
	public GameObject groundPlane;
	
	public Vector2 size;
	
	private float hexX;
	private float hexZ;
	private float groundX;
	private float groundZ;
	
	// Use this for initialization
	
	void SetSeizes()
	{
		hexX = hexTile.renderer.bounds.size.x;
		hexZ= hexTile.renderer.bounds.size.z;
		groundX = groundPlane.renderer.bounds.size.x;
		groundZ = groundPlane.renderer.bounds.size.y;
	}
	
	Vector2 calcGridSize()
	{
		
	}
	
	Vector3 calculateWorldPosition (Vector2 gridPosition)
	{
		Vector3 initialPosition = new Vector3();
		float offset = 0;
		if(gridPosition.y % 2 != 0)
		{
			offset = hexX /2;
		}
		
		float x = 0;
	}
	
	void Start () {
		
		//hexTileSize.x = hexPrefab.
		
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
