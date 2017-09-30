using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class startFight : MonoBehaviour {

	public GameObject slot1;
	public GameObject slot2;
	public GameObject slot3;
	public GameObject slot4;

	public GameObject mainWindow;
	public GameObject courtRoom;

	void Start () {
		
	}

	public void updateSkills(){
		mainWindow.SetActive (false);
		courtRoom.SetActive (true);

		Debug.Log ("Name: " + this.GetComponentInChildren<UpgradeData> ().skillSlots [1] ["Name"]);

		slot1.GetComponentInChildren<Text> ().text = Convert.ToString(this.GetComponentInChildren<UpgradeData>().skillSlots[1]["Name"]);
		slot2.GetComponentInChildren<Text> ().text = Convert.ToString(this.GetComponentInChildren<UpgradeData>().skillSlots[2]["Name"]);
		slot3.GetComponentInChildren<Text> ().text = Convert.ToString(this.GetComponentInChildren<UpgradeData>().skillSlots[3]["Name"]);
		slot4.GetComponentInChildren<Text> ().text = Convert.ToString(this.GetComponentInChildren<UpgradeData>().skillSlots[4]["Name"]);

	}

	public void endFight(){
		courtRoom.SetActive (false);
		mainWindow.SetActive (true);
	}
}
