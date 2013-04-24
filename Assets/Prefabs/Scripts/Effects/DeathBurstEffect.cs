using UnityEngine;
using System.Collections;

public class DeathBurstEffect : BurstEffect {

	public DeathBurstEffect() : base("DeathBurst"){
		addEffect(new DeathEffect(2));
		addEffect(new DeathEffect(-1));
	}
}
