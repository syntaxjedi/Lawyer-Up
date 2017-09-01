using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class textUpdateRemote : MonoBehaviour {
	public GameObject pointsUpdate;
	public GameObject warning;
	public GameObject folder;
	float time = 1f;
	public bool warningBool;
	points playerPoints = new points ();

	public void pointsPlus(){
		playerPoints.score = playerPoints.score + playerPoints.pointValue;
		valueDisplay (pointsUpdate, "Study Points: "+playerPoints.score);
	}

	public void deBug(){
		playerPoints.score = playerPoints.score + 100;
		valueDisplay (pointsUpdate, "Study Points: " + playerPoints.score);
	}

	void Update(){
		if (warningBool == true && time > 0) {
			warning.SetActive (true);
			time -= Time.deltaTime;
			warning.transform.SetAsLastSibling();
		} else if (time <= 0) {
			warningBool = false;
			warning.SetActive (false);
			time = 1f;
			warning.transform.SetSiblingIndex (0);
		}
	}

	public void valueDisplay(GameObject obj, string updateText){
		if (obj.GetComponent<Text> ()) {
			obj.GetComponent<Text> ().text = updateText;		
		} else if (obj.GetComponentInChildren<Text> ()) {
			obj.GetComponentInChildren<Text> ().text = updateText;
		}
	}
}
