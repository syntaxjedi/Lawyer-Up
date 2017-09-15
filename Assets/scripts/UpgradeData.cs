using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeData : MonoBehaviour {
	//string name
	//float cost
	//int owned
	//int pointvalue
	//int pointupgrade
	Dictionary<string, object> coffee = new Dictionary<string, object>();
	Dictionary<string, object> law = new Dictionary<string, object>();
	public Dictionary<string, Dictionary<string, object>> dicts = new Dictionary<string, Dictionary<string, object>>();
	void Start(){
		coffee.Add ("Name", "Coffee");
		coffee.Add ("BaseCost", 4f);
		coffee.Add ("NewCost", 4f);
		coffee.Add ("Owned", 0);
		coffee.Add ("Growth", 1.07f);
		coffee.Add ("pointValue", 1);
		coffee.Add ("PointUpgrade", 1);

		law.Add("Name", "Law");
		law.Add("BaseCost", 60f);
		law.Add ("NewCost", 60f);
		law.Add("Owned", 0);
		law.Add ("Growth", 1.07f);
		law.Add("PointValue", 4);
		law.Add("PointUpgrade", 2);

		dicts.Add ("Coffee", coffee);
		dicts.Add ("Law", law);
	}

	public void updateUpgrades(string name, string param, float update){
		dicts [name] [param] = update;
		Debug.Log ("Dictionary Updated: " + name + " " + param + " " + update);
	}
}
