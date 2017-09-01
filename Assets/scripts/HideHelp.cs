using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideHelp : MonoBehaviour {

	bool showing = true;
	public GameObject tutorial;
	void Start () {
		this.transform.SetAsLastSibling ();
	}

	public void showHideHelp(){
		if (showing) {
			tutorial.SetActive (false);
			showing = false;
		} else if (!showing) {
			tutorial.SetActive (true);
			tutorial.transform.SetAsLastSibling ();
			showing = true;
		}
	}
}
