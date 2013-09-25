using UnityEngine;
using System.Collections;
using System.IO;


//Singleton
public class SaveLoadManager
{
	public static SaveLoadManager instance = new SaveLoadManager();
	public Savefile savefile;
	
	public string SaveFolderLoc = "/Saves";
	public string SaveFileLoc = "/save.txt";
	
	
	public bool LoadSaveFile()
	{
		if(!Directory.Exists(Application.dataPath + SaveFolderLoc))
		{
			Directory.CreateDirectory(Application.dataPath + SaveFolderLoc);
		}
		
		string path = Application.dataPath + SaveFolderLoc + SaveFileLoc;
		
		savefile = new Savefile();
		
		if(File.Exists(path))
		{
			StreamReader sr = new StreamReader(path);
			string s = sr.ReadToEnd();
			sr.Close();
			
			savefile.load(s);
			return true;
		}
		else
		{
			Debug.Log("No save file found");
			return false;
		}
		
	}
	
	public void SaveSaveFile()
	{
		if(!Directory.Exists(Application.dataPath + SaveFolderLoc))
		{
			Directory.CreateDirectory(Application.dataPath + SaveFolderLoc);
		}
		
		
		string path = Application.dataPath + SaveFolderLoc + SaveFileLoc;
		
		if(File.Exists(path))
		{
			File.Delete(path);
		}
		
		StreamWriter sw = new StreamWriter(path);
		sw.WriteLine(savefile.save());
		sw.Close();
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
public class Savefile
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
		guiPosition = new Vector2 (float.Parse(split2[0]), float.Parse(split2[1]));
	}
}
