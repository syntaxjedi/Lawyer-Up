//Allows to dynamically set new upgrades
//with this one script rather than set
//a new script with each upgrade


using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class BuyUpgrades : MonoBehaviour {
	private static int numOwned;
	private static float bCost;
	private static float nCost;
	private static float _growth;
	private static string _name;

	public GameObject warning;
	public GameObject cash;
	public GameObject main;
	private static GameObject _button;
	private static GameObject _clicker;
	private static GameObject _owned;

	cash currentMoney = new cash();
	upgrades upgradeForm = new upgrades();

	void Start () {
	}

	public void getButton(GameObject button){
		_button = button;
	}

	public void getClicker(GameObject clicker){
		_clicker = clicker;
	}

	public void getOwned(GameObject owned){
		_owned = owned;
	}

	public void getName(string name){
		_name = name;
	}
	public void getVar(){
		numOwned = Convert.ToInt32(main.GetComponentInChildren<UpgradeData>().upgradeDicts[_name]["Owned"]);
		bCost = (float) main.GetComponentInChildren<UpgradeData>().upgradeDicts[_name]["BaseCost"];
		nCost = (float) main.GetComponentInChildren<UpgradeData> ().upgradeDicts [_name] ["NewCost"];
		_growth = (float) main.GetComponentInChildren<UpgradeData>().upgradeDicts[_name]["Growth"];
	}
	public void buyUpgrade(){
		if (currentMoney.money >= nCost && nCost > 0 || nCost <= 0 && currentMoney.money >= bCost) {
			if (!_clicker.activeInHierarchy) {
				_clicker.SetActive (true);
			}
			numOwned++;
			currentMoney.money = Mathf.Round ((currentMoney.money - nCost) * 100) / 100;
			nCost = upgradeForm._cost (bCost, _growth, numOwned);
			//_clicker.GetComponentInChildren<sliderTest> ().productionUpgrade ();
			_clicker.GetComponentInChildren<sliderTest>().speedUpgrade();
			main.GetComponentInChildren<UpgradeData>().updateUpgrades(_name, "NewCost", nCost);
			main.GetComponentInChildren<UpgradeData> ().updateUpgrades (_name, "Owned", numOwned);

			main.GetComponentInChildren<textUpdateRemote> ().valueDisplay (cash, "Cash: $" + currentMoney.money);
			main.GetComponentInChildren<textUpdateRemote> ().valueDisplay (_button, _name + ": $" + nCost);
			main.GetComponentInChildren<textUpdateRemote> ().valueDisplay (_owned, "(" + numOwned + ")");
		} else {
			main.GetComponentInChildren<textUpdateRemote> ().valueDisplay (warning, "Not Enough Cash!");
			main.GetComponentInChildren<textUpdateRemote> ().warningBool = true;
		}
	}
	public void debugMoney(){
		currentMoney.money = currentMoney.money + 100;
		main.GetComponentInChildren<textUpdateRemote> ().valueDisplay (cash, "Cash: $" + currentMoney.money);
	}
}
