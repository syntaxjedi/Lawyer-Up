using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class points{
	private static float b_Value = 1f;
	private static float b_Score;
	private static float b_Bonus = 1f;

	public float pointValue {
		get{ return b_Value; }
		set{ b_Value = value; }
	}

	public float score{
		get{return b_Score;}
		set{b_Score = value;}

	}

	public float bonus{
		get{ return b_Bonus; }
		set{b_Bonus = value;}
	}

	public float upgradeValue{
		get{ return p_val (b_Value, b_Bonus); }
	}

	public float p_val(float val, float bon){
		float mult = val * bon;
		return mult;
	}
}