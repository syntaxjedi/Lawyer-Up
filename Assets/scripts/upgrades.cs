using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgrades{

	public float _cost (float baseCost, float rateGrowth, float numOwned){
		float _ucost = Mathf.Round(baseCost * (Mathf.Pow (rateGrowth, numOwned))*100)/100;
		return _ucost;
	}

	public float production(float bProd,float prod){
		float nProd = prod + bProd;
		return nProd;
	}

}


// rate growth = how much i want each step multiplied
// linear step = cost * growth
// to make exponential, multiply growth by number owned each step
// exponential step = cost * (growth^owned)
// example growth step: 1.05 base
//			   owned 1: 1.05 = 1.05 * 25 = 26.25
//			   owned 2: 1.1 = 1.05^2 * 25 = 27.56
//			   owned 3: 1.16 = 1.05^3 * 25 = 28.94
//			  owned 10: 1.63 = 1.05^10 * 25 = 40.72
//			  owned 20: 2.65 = 1.05^20 * 25 = 66.33
//			  owned 40: 7.03 = 1.05^40 * 25 = 176
//
//
//
// coffee production stops ~490cost/~61gen
//
//
//