using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class textUpdateRemote : MonoBehaviour {
	public GameObject pointsUpdate;
	public GameObject warning;
	public GameObject lose;
	public GameObject folder;
	float wTime = 1f;
	float lTime = 1f;
	public bool warningBool;
	public bool loseBool;
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
		if (warningBool == true && wTime > 0) {
			warning.SetActive (true);
			wTime -= Time.deltaTime;
			warning.transform.SetAsLastSibling();
			Debug.Log ("Warning Time: " + wTime);
		} else if (wTime <= 0) {
			warningBool = false;
			warning.SetActive (false);
			wTime = 1f;
			warning.transform.SetSiblingIndex (0);
		}

		if (loseBool == true && lTime > 0) {
			lose.SetActive (true);
			lTime -= Time.deltaTime;
			warning.transform.SetAsLastSibling();
		} else if (lTime <= 0) {
			loseBool = false;
			lose.SetActive (false);
			lTime = 1f;
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
