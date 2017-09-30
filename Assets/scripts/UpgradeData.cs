using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class UpgradeData : MonoBehaviour {
	
	Dictionary<string, object> coffee = new Dictionary<string, object>();
	Dictionary<string, object> law = new Dictionary<string, object>();

	Dictionary<string, object> objection = new Dictionary<string, object>();
	Dictionary<string, object> badger = new Dictionary<string, object>();
	Dictionary<string, object> impress = new Dictionary<string, object>();
	Dictionary<string, object> evidence = new Dictionary<string, object>();
	Dictionary<string, object> nulled = new Dictionary<string, object>();

	public Dictionary<string, Dictionary<string, object>> upgradeDicts = new Dictionary<string, Dictionary<string, object>>();
	public Dictionary<int, Dictionary<string, object>> skills = new Dictionary<int, Dictionary<string, object>> ();
	public Dictionary<int, Dictionary<string, object>> skillSlots = new Dictionary<int, Dictionary<string, object>>();

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

		objection.Add ("Position", 1);
		objection.Add ("Name", "Objection");
		objection.Add ("Power", 10);
		objection.Add ("Cost", 5);
		objection.Add ("Description", "Objection Your Honor!");

		badger.Add ("Position", 2);
		badger.Add ("Name", "Badger Witness");
		badger.Add ("Power", 15);
		badger.Add ("Cost", 10);
		badger.Add ("Description", "Witnesses hate badgers!");

		impress.Add ("Position", 3);
		impress.Add ("Name", "Impress Jury");
		impress.Add ("Power", 5);
		impress.Add ("Cost", 5);
		impress.Add ("Description", "Is that a shiny quarter behind your ear?");

		evidence.Add ("Position", 4);
		evidence.Add ("Name", "Present Evidence");
		evidence.Add ("Power", 20);
		evidence.Add ("Cost", 15);
		evidence.Add ("Description", "That could be anybody's blood!");

		nulled.Add ("Position", 0);
		nulled.Add ("Name", "No skill assigned");
		nulled.Add ("Power", "N/A");
		nulled.Add ("Cost", "N/A");
		nulled.Add ("Description", "Go to the skills folder to add a new skill");

		upgradeDicts.Add ("Coffee", coffee);
		upgradeDicts.Add ("Law", law);

		skills.Add (1, objection);
		skills.Add (2, badger);
		skills.Add (3, impress);
		skills.Add (4, evidence);
		skills.Add (5, nulled);

		skillSlots.Add (1, skills[1]);
		skillSlots.Add (2, skills[2]);
		skillSlots.Add (3, skills[3]);
		skillSlots.Add (4, skills[4]);
	}

	public void updateUpgrades(string name, string param, float update){
		upgradeDicts [name] [param] = update;
	}

	public void testUpdate(){
		updateActiveSkills ("Objection", 3);
	}

	public void updateActiveSkills(string name, int pos){
		for (int i = 1; i < skills.Count; i++) {
			if (skills [i] ["Name"] == name) {
				if (Convert.ToInt32(skills [i] ["Position"]) > 0) {
					int nul = Convert.ToInt32(skills [i] ["Position"]);
					skillSlots [nul] = skills[5];
				}
				skills [i] ["Position"] = pos;
				skillSlots [pos] = skills [i];
			} else if (Convert.ToInt32(skills [i] ["Position"]) == pos && skills [i] ["Name"] != name) {
				skills [i] ["Position"] = 0;
			}
		}
	}
}