using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ButtonControl : MonoBehaviour {

	bool doorKey;

	void Update(){
		if (doorKey)
		{
			if (Input.GetKeyDown (KeyCode.E)) {
				Destroy (GameObject.FindWithTag ("Door"));
				doorKey = false;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.transform.tag == "Player")
		{
				doorKey = true;
		}
	}

	void OnTriggerExit2D(Collider2D col){
		if (col.tag == "Player") {
			doorKey = false;
		}
	}

	void OnGUI()
	{
		if (doorKey)
		{
			GUI.Box(new Rect(0, 60, 500, 25), "Press E to open");
		}
	}
}
