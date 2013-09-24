using UnityEngine;
using System.Collections;

[ExecuteInEditMode]

public class SpaceGui : MonoBehaviour 
{
	public GUISkin skin;
	public Rect GuiPosition;
	public Rect InventoryBox;
	
	private bool inventoryOpen;
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void OnGUI () 
	{
		GUI.skin = skin;
		//GUILayout.BeginArea(GuiPosition, (GUIStyle)"Window");
			
		
		GuiPosition = GUI.Window(0, GuiPosition, HealthBox, "Health");
		
		if(inventoryOpen)
		{
			InventoryBox = GUI.Window(1, InventoryBox, Inventory, "Inventory");
		}
		//GUILayout.EndArea();
	}
	public bool IsOverGui(Vector2 mousePos){
		
		if(inventoryOpen)
		{
			return GuiPosition.Contains(mousePos) || InventoryBox.Contains(mousePos);
		}
		else
		{
			return GuiPosition.Contains(mousePos);
		}
	}
	
	void HealthBox (int id)
	{
		GUILayout.Space(30);
		
			GUILayout.BeginHorizontal();
		
			GUILayout.BeginVertical();
			GUILayout.Label("Hello World");
			GUILayout.Label("This is my GUI", (GUIStyle)"ShortLabel");
			GUILayout.EndVertical();
			if(GUILayout.Button("i", GUILayout.Width(50), GUILayout.Height(50)))
			{
				inventoryOpen = !inventoryOpen;
			}
			GUILayout.EndHorizontal();
		
			GUI.DragWindow(new Rect(0,0,10000,10000));
	}
	
	void Inventory (int id)
	{
		GUILayout.Space(30);
		int inventoryItems = 25;
		int numberOfButtons = 0;
		for(int i = 0; i<inventoryItems; i++)
		{
			if(numberOfButtons==0)
			{
				GUILayout.BeginHorizontal();
			}
			
			if(GUILayout.Button("B"+i, GUILayout.Width(50), GUILayout.Height(50)))
			{
				Debug.Log("Clicked button "+i);
			}
			
			numberOfButtons++;
			if(numberOfButtons == 5)
			{
				GUILayout.EndHorizontal();
				numberOfButtons = 0;
			}
		}
			
		if(numberOfButtons != 0)
		{
				GUILayout.EndHorizontal();
		}
		
		GUI.DragWindow(new Rect(0,0,10000,10000));
	}
}
