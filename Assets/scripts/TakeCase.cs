using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeCase : MonoBehaviour {

	float _sp;
	float _payout;
	float winPercent;
	public GameObject textUpdate;
	public GameObject cashDisplay;
	public GameObject pointsDisplay;
	points studyPoints = new points();
	cash newCash = new cash();
	void Start () {
		
	}

	public void sp(float sp){
		_sp = sp;
	}

	public void payout(float payout){
		_payout = payout;
	}

	public void calculateCase(){
		if (studyPoints.score < _sp) {
			winPercent = Random.Range ((studyPoints.score % _sp), _sp);
			Debug.Log ("Win Chance: " + winPercent);
			if (winPercent == _sp) {
				studyPoints.score = studyPoints.score - _sp;
				newCash.money = newCash.money + _payout;
				textUpdate.GetComponent<textUpdateRemote> ().valueDisplay (cashDisplay, "Cash: $" + newCash.money);
				textUpdate.GetComponent<textUpdateRemote> ().valueDisplay (pointsDisplay, "Study Points: " + studyPoints.score);
			}
		} else if(studyPoints.score >= _sp){
			studyPoints.score = studyPoints.score - _sp;
			newCash.money = newCash.money + _payout;
			textUpdate.GetComponent<textUpdateRemote> ().valueDisplay (cashDisplay, "Cash: $" + newCash.money);
			textUpdate.GetComponent<textUpdateRemote> ().valueDisplay (pointsDisplay, "Study Points: " + studyPoints.score);
		}
	}

}
