using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

	public static bool doorKey;
	public bool open = false;
	public bool close;
	public bool inTriggerDoor;

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Player"){
			inTriggerDoor = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		inTriggerDoor = false;
	}

	void Update()
	{
		if (doorKey)
		{
			Destroy(gameObject);
			doorKey = false;
		}
	}
	void OnGUI()
	{
		if (inTriggerDoor)
		{
			GUI.Box(new Rect(0, 60, 200, 25), "Locked");
		}
	}
}