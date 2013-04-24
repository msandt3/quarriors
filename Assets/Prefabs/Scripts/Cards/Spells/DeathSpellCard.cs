using UnityEngine;
using System.Collections;

public class DeathSpellCard : SpellCard {
	
	public DeathSpellCard() : base(5,"DeathSpell"){
		AddEffect(new DeathBurstEffect());
	}
}
