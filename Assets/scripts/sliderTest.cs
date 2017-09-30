using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class sliderTest : MonoBehaviour {
	public Slider slider;
	public float maxTime = 100f;
	float maxVal = 100f;
	float currentTime;
	float timer;
	float bProduction = 1f;
	float nProduction;
	int mult;
	int multCap;
	public bool solid = false;
	public GameObject coffee;
	public GameObject scoreUpdate;
	public GameObject score;
	upgrades prodUp = new upgrades();
	//public textUpdateRemote update;
	points playerPoints = new points();
	void Start () {
		nProduction = bProduction;
	}
	void Update () {
		timer = Mathf.MoveTowards (timer, 100f, maxTime * Time.deltaTime);

		if (solid == false) {
			slider.value = timer;
			if (slider.value == slider.maxValue && maxTime < 500f) {
				slider.value = slider.minValue;
			}
		}else if (solid == true) {
			slider.value = slider.maxValue;
		}

		if (timer >= maxVal) {
			timer = 0;
			playerPoints.score = Mathf.Round((playerPoints.score + nProduction)*100)/100;
			scoreUpdate.GetComponent<textUpdateRemote> ().valueDisplay (score, "Study Points: " + playerPoints.score);
		}
	}

	public void productionUpgrade(){
		nProduction = prodUp.production (bProduction, nProduction);
		Debug.Log ("nProduction: " + nProduction);
	}

	public void speedUpgrade(){
		mult++;
		if (mult == 10 && multCap < 5) {
			multCap++;
			mult = 0;
			maxTime = prodUp.speed (maxTime);
		}
	}
}
