using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cash{
	private static float _cash;

	public float money{
		get{return _cash;}
		set {_cash = value;}
	}
}
