using UnityEngine;
using System.Collections;

public class DefenderBurstEffect : BurstEffect {
	
	public DefenderBurstEffect() : base("Defender"){
		this.Combined = true;
		addEffect(new DefenderGloryEffect());
	}
}
