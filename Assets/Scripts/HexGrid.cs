using UnityEngine;
using System.Collections;

public class HexGrid : MonoBehaviour {

	public GameObject hexTile;
	public GameObject groundPlane;
	public GameObject player;
	private bool GridSpawned = false;
	
	private float hexWidth;
	private float hexLength;
	private float groundWidth;
	private float groundLength;
	private float groundCornerX;
	private float groundCornerZ;
	
	// Use this for initialization
	
	void SetSizes()
	{
		hexWidth = hexTile.renderer.bounds.size.x;
		hexLength= hexTile.renderer.bounds.size.z;
		groundWidth = groundPlane.renderer.bounds.size.x;
		groundLength = groundPlane.renderer.bounds.size.z;
		
		groundCornerX = groundPlane.renderer.bounds.min.x;
		groundCornerZ = groundPlane.renderer.bounds.max.z;
		
		Debug.Log("Corner X loc:"+groundCornerX);
		Debug.Log("Corner Y loc:"+groundCornerZ);
	}
	
	
	//Method to calculate the position of the first hexagon tile
    //The center of the hex grid is (0,0,0)
	
	Vector3 calculateInitialPosition()
	{
		Vector3 initPos;
		
		//TODO: Get plane position and spawn it there
		
		
		//float x = -groundWidth/2 + hexWidth/2; 
		//float z = groundLength /2 - hexWidth /2;
		
		var realCornerX=(hexWidth/1.25f)+groundCornerX;
		var realCornerZ=(-hexLength/2)+groundCornerZ;;
        initPos = new Vector3(realCornerX,0, realCornerZ);
		
		bool cake;
		return initPos;
	}
	
	Vector2 calcGridSize()
	{
		//According to the math textbook hexagon's side length is half of the height
		float hexSideLength = hexLength / 2;
		
		//the number of whole hex sides that fit inside inside ground height
		int nrOfSides = (int)(groundLength/hexSideLength);
		
		//I will not try to explain the following calculation because I made some assumptions, which might not be correct in all cases, to come up with the formula. So you'll have to trust me or figure it out yourselves.
		int gridLengthInHexes = (int)(nrOfSides*2 / 3);
		
		//When the number of hexes is even the tip of the last hex in the offset column might stick up.
        //The number of hexes in that case is reduced.
		if(gridLengthInHexes%2==0 && (nrOfSides+0.5f)*hexSideLength > groundLength)
		{
			gridLengthInHexes--;
		}
		
		int vectorX = (int)(groundWidth/hexWidth);
		int vectorY = gridLengthInHexes;
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
		float z = initPosition.z - gridPosition.y * hexLength * 0.75f;
		
        float yHeightOverGround = 0.1f;
		
		return new Vector3(x, yHeightOverGround, z);
	}
	
	void createGrid()
	{
		Vector2 gridSize = calcGridSize();
		GameObject hexGridGo = new GameObject("TestGrid");
		
		for (int y = 0; y<gridSize.y; y++)
		{
			float sizeX = gridSize.x;
			if(y%2 !=0 && (gridSize.x+0.5f)*hexWidth>groundWidth)
			{
				sizeX--;
			}
			for(int x= 0; x<sizeX; x++)
			{
				GameObject hex = (GameObject)Instantiate(hexTile);
				Vector2 gridPos = new Vector2(x,y);
				hex.transform.position = calculateWorldPosition(gridPos);
				
				hex.name = "Hex {"+gridPos.x+","+gridPos.y+"}";
				
				hex.transform.parent = hexGridGo.transform;
			}
		}
		GridSpawned = true;
		
	}
	void Start () 
	{
		SetSizes();
		createGrid();
		
		if(GridSpawned)
		{
			//Mess
			Vector2 spawnlocation = new Vector2(0,0);
			float cubeWidth = player.renderer.bounds.size.x;
			GameObject Newplayer = (GameObject)Instantiate(player,calculateWorldPosition(spawnlocation), player.transform.rotation);
			Newplayer.transform.position = new Vector3(Newplayer.transform.position.x - (cubeWidth/2) , 3f , Newplayer.transform.position.z);
			//iTween.MoveBy(Newplayer, iTween.Hash("x", 2, "easeType", "easeInOutExpo", "loopType", "pingPong", "delay", .1));
		}
		
		Vector2 singleTile = new Vector2(1,2);
		GameObject hex = (GameObject)Instantiate(hexTile);
		hex.transform.position = calculateWorldPosition(singleTile);
		hex.name = "TESTTILE @ 1,2";
		hex.renderer.material.color = Color.red;
	}
}
