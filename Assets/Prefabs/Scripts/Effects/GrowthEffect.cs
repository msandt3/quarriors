using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GrowthEffect : MultipleEffect {
	
	public GrowthEffect() : base("Growth"){
		addEffect(new GainQuiddity(2));
		addEffect(new Reroll(2,false));
	}
}
