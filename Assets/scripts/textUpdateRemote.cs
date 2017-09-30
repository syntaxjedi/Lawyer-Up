using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class textUpdateRemote : MonoBehaviour {
	public GameObject pointsUpdate;
	public GameObject warning;
	public GameObject folder;
	public GameObject toolTip;
	public GameObject main;

	float wTime = 1f;
	float lTime = 1f;
	public bool warningBool;
	public bool follow;

	Vector3 mousePos;

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
		} else if (wTime <= 0) {
			warningBool = false;
			warning.SetActive (false);
			wTime = 1f;
			warning.transform.SetSiblingIndex (0);
		}

		if (follow) {
			mousePos = Input.mousePosition;
			mousePos = Camera.main.ScreenToWorldPoint (mousePos);
			toolTip.transform.position = new Vector2 (mousePos.x, mousePos.y);
		}
	}

	public void valueDisplay(GameObject obj, string updateText){
		if (obj.GetComponent<Text> ()) {
			obj.GetComponent<Text> ().text = updateText;		
		} else if (obj.GetComponentInChildren<Text> ()) {
			obj.GetComponentInChildren<Text> ().text = updateText;
		}
	}

	public void tooltipActive(int pos){
		toolTip.GetComponentInChildren<Text> ().text = 
			this.GetComponentInChildren<UpgradeData> ().skillSlots [pos] ["Description"] + "\n" +
			"Power: " + "<color=red>" +this.GetComponentInChildren<UpgradeData> ().skillSlots [pos]["Power"] + "</color>" + "\n" + 
			"Cost: " + "<color=lime>" + this.GetComponentInChildren<UpgradeData> ().skillSlots [pos]["Cost"] + "</color>";
		
		toolTip.transform.SetAsLastSibling ();
		follow = true;
		toolTip.SetActive (true);
	}

	public void toolTipInActive(){
		toolTip.SetActive (false);
		follow = false;
	}
}
