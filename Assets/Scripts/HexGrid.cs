using UnityEngine;
using System.Collections;

public class HexGrid : MonoBehaviour {

	public GameObject hexTile;
	public GameObject groundPlane;
	
	private float hexWidth;
	private float hexLength;
	private float groundWidth;
	private float groundLength;
	
	// Use this for initialization
	
	void SetSizes()
	{
		hexWidth = hexTile.renderer.bounds.size.x;
		hexLength= hexTile.renderer.bounds.size.z;
		groundWidth = groundPlane.renderer.bounds.size.x;
		groundLength = groundPlane.renderer.bounds.size.y;
	}
	
	
	//Method to calculate the position of the first hexagon tile
    //The center of the hex grid is (0,0,0)
	
	Vector2 calculateInitialPosition()
	{
		Vector3 initPos;
		
		
		float x = -groundWidth/2 + hexWidth/2; 
		float y = groundLength /2 - hexWidth /2;
        initPos = new Vector3(x, 0, y);
		
		return initPos;
	}
	
	Vector2 calcGridSize()
	{
		//According to the math textbook hexagon's side length is half of the height
		float hexSideLength = hexWidth / 2;
		
		//the number of whole hex sides that fit inside inside ground height
		int nrOfSides = (int)(groundWidth/hexSideLength);
		int gridLengthInHexes = (int)(nrOfSides*2/3);
		
		//When the number of hexes is even the tip of the last hex in the offset column might stick up.
        //The number of hexes in that case is reduced.
		if(gridLengthInHexes%2==0 && (nrOfSides+0.5f)*hexSideLength > groundLength)
		{
			gridLengthInHexes--;
		}
		
		int vectorX = (int)(groundWidth/hexWidth);
		int vectorY = (int)(gridLengthInHexes);
		return new Vector2 (vectorX, vectorY);
		
	}
	
	//Converting hex coordinates to grid coordinates, using offseting Y by half a hex every other row
	Vector3 calculateWorldPosition (Vector2 gridPosition)
	{
		Vector3 initPosition = calculateInitialPosition();
		
		float offset = 0;
		if(gridPosition.y % 2 != 0)
		{
			//offseting half a hex every other row
			offset = hexWidth /2;
		}
		
		float x = initPosition.x + offset + gridPosition.x * hexWidth ;
		float z = initPosition.y - gridPosition.y * hexLength * 0.75f;
		
        
		
		return new Vector3(x, 0, z);
	}
	
	void createGrid()
	{
		Vector2 gridSize = calcGridSize();
		GameObject hexGridGo = new GameObject("TestGrid");
		
		for (int y = 0; y<gridSize.y; y++)
		{
			float sizeX = gridSize.x;
			if(y%2 !=0 && (gridSize.x+0.5f)*hexWidth>groundLength)
			{
				sizeX--;
			}
			for(int x= 0; x<sizeX; x++)
			{
				GameObject hex = (GameObject)Instantiate(hexTile);
				Vector2 gridPos = new Vector2(x,y);
				hex.transform.position = calculateWorldPosition(gridPos);
				hex.transform.parent = hexGridGo.transform;
			}
		}
		
	}
	void Start () 
	{
		SetSizes();
		createGrid();
	}
}
