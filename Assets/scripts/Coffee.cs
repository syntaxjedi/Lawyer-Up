using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coffee: MonoBehaviour{
	public float _bCoffeeCost = 4f;
	float coffeeCostNew = 4f;
	float coffeeGrowth = 1.07f;
	float coffeeOwned = 0;
	public GameObject cash;
	public GameObject textUpdate;
	public GameObject slider;
	public GameObject numOwned;
	//points coffeePoints = new points();
	upgrades coffeeUpgrades = new upgrades();
	cash coffeeMoney = new cash();
	void Start () {
		textUpdate.GetComponent<textUpdateRemote> ().valueDisplay (this.gameObject, "Coffee: $4");
	}

	public void buyCoffee () {
		if (coffeeMoney.money >= coffeeCostNew) {
			if (!slider.activeInHierarchy) {
				slider.SetActive (true);
			}
			coffeeOwned++;
			coffeeMoney.money = Mathf.Round((coffeeMoney.money - coffeeCostNew)*100)/100;
			coffeeCostNew = coffeeUpgrades._cost (_bCoffeeCost, coffeeGrowth, coffeeOwned);
			slider.GetComponent<sliderTest> ().productionUpgrade ();
			textUpdate.GetComponent<textUpdateRemote> ().valueDisplay (cash, "Cash: $" + coffeeMoney.money);
			textUpdate.GetComponent<textUpdateRemote> ().valueDisplay (this.gameObject, "Coffee: $" + coffeeCostNew);
			textUpdate.GetComponent<textUpdateRemote> ().valueDisplay (numOwned, "(" + coffeeOwned + ")");
		} else {
			textUpdate.GetComponent<textUpdateRemote> ().warningBool = true;
			Debug.Log ("Current Money: " + coffeeMoney.money);
		}

		if (coffeeOwned == 20 || coffeeOwned == 50 || coffeeOwned == 100) {
			slider.GetComponent<sliderTest> ().maxTime = slider.GetComponent<sliderTest> ().maxTime * 1.5f;
			if (coffeeOwned == 100) {
				slider.GetComponent<sliderTest> ().solid = true;
			}
		}

	}


	public float cOwned{
		get{return coffeeOwned;}
	}

	public float cGrowth{
		get{return coffeeGrowth;}
	}

}
