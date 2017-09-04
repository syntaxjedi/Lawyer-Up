using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideHelp : MonoBehaviour {

	bool showing = true;
	public GameObject tutorial;
	void Start () {
		Time.timeScale = 0;
		this.transform.SetAsLastSibling ();
	}

	public void showHideHelp(){
		if (showing) {
			tutorial.SetActive (false);
			Time.timeScale = 1;
			showing = false;
		} else if (!showing) {
			tutorial.SetActive (true);
			tutorial.transform.SetAsLastSibling ();
			Time.timeScale = 0;
			showing = true;
		}
	}
}
