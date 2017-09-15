using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayDataType {
	public string _name;
	public float _cost;
	public int _owned;
	public int _pointValue;
	public int _pointUpgrade;

	public ArrayDataType(string name, float cost, int owned, int pointValue, int pointUpgrade){
		_name = name;
		_cost = cost;
		_owned = owned;
		_pointValue = pointValue;
		_pointUpgrade = pointUpgrade;
	}
}
