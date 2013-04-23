using UnityEngine;
using System.Collections;

public class GoblinBurstEffect : BurstEffect {
	
	public GoblinBurstEffect() : base("Goblin"){
		this.Combined = false;
		this.addEffect(new GainQuiddity(1));
	}
}
