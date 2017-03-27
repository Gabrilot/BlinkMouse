using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBox : MonoBehaviour {

	public GameObject text;
	public GameObject panel;
	bool inText;
	bool textVisible;
	Teleporter teleport;
	Controller2D soric;
	PlayerPhysics soric1;

	void Start () {
		textVisible = false;
		text.SetActive (false);
		panel.SetActive (false);

		teleport = FindObjectOfType<Teleporter> ();
		soric = FindObjectOfType<Controller2D> ();
		soric1 = FindObjectOfType<PlayerPhysics> ();
	}

	void Update () {
		if (inText && Input.GetKeyDown (KeyCode.E))
		{

			textVisible = !textVisible ;
			if( !textVisible )
				inText = false;
			text.SetActive (textVisible);
			panel.SetActive (textVisible);
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.transform.tag == "Player") {
			inText = true;

		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.transform.tag == "Player") {
			inText = false;
			text.SetActive (false);
			panel.SetActive (false);
			textVisible = false;
		}
	}
}