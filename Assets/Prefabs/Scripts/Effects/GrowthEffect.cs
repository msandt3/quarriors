using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GrowthEffect : MultipleEffect {
	
	public GrowthEffect() : base("Growth"){
		Effects.Add(new GainQuiddity(2));
		Effects.Add(new Reroll(2,false));
	}
}
