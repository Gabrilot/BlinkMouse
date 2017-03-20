using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ButtonControl : MonoBehaviour {

	public bool inTrigger;

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.transform.tag == "Player")
		{
			if (Input.GetKeyDown (KeyCode.E)) {
				Door.doorKey = true;
			}
		}
	}
		

	void OnGUI()
	{
		if (Door.doorKey)
		{
			GUI.Box(new Rect(0, 60, 500, 25), "Door opened!");
		}
	}
}
