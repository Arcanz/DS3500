using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters;


//Singleton
public class SaveLoadManager
{
	public static SaveLoadManager instance = new SaveLoadManager();
	
	public OurSavefile savefile;
	
	public void SaveRealSaveFile()
	{
		if(false == false)
		{}
		string path = Application.dataPath + "/mysave.txt";
		bool fileExists = File.Exists(path);
		
		if(fileExists)
		{
			
		}
	}

	
	//Method with same name but different input.
	public void SavePref(string key, float val)
	{
		PlayerPrefs.SetFloat(key, val);
	}
	
	public void SavePref(string key, string val)
	{
		PlayerPrefs.SetString(key, val);
	}
	
	public void SavePref(string key, int val)
	{
		PlayerPrefs.SetInt(key, val);
	}
	
	public float LoadPrefFloat(string key, float defaultValue = 0)
	{
		if(PlayerPrefs.HasKey(key))
		{
			return PlayerPrefs.GetFloat(key);
		}
		else
		{
			return defaultValue;
		}
	}
}

[System.Serializable]
public class OurSavefile
{
	public Vector3 playerPosition;
	public Vector2 guiPosition;
	
	public string save()
	{
		string s = playerPosition.x + ":" + playerPosition.z;
		s += '\n';
		s += guiPosition.x+ ":" + guiPosition.y;
		return s;
	}
	
	public void load(string text)
	{
		string[] lines = text.Split('\n');
		string[] split = lines[0].Split(':');
		playerPosition = new Vector3(float.Parse(split[0]),0, float.Parse(split[1]));
		
		string[] split2 = lines[1].Split(':');
		guiPosition = new Vector2 (float.Parse(split[0]), float.Parse(split[1]));
	}
}
