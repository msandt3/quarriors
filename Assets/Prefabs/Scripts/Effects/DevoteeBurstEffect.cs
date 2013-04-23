using UnityEngine;
using System.Collections;

public class DevoteeBurstEffect : BurstEffect {

	public DevoteeBurstEffect() : base("Devotee"){
		this.Combined = false;
		this.addEffect(new DefenseEffect());
	}
}
