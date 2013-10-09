using UnityEngine;
using System.Collections;

public class MoveSample : MonoBehaviour
{	
	void Start(){
		Hashtable myHash = new Hashtable();
		myHash["x"] = 5;
		myHash["easeType"] = iTween.EaseType.easeInBack;
		
		iTween.MoveTo(gameObject, myHash);
		
		iTween.MoveBy(gameObject, iTween.Hash("x", 2, "easeType", "easeInOutExpo", "loopType", "pingPong", "delay", .1));
	}
}

