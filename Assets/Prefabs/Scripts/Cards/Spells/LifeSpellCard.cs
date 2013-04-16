using UnityEngine;
using System.Collections;

public class LifeSpellCard : SpellCard {
	
	public LifeSpellCard() : base(4,"LifeSpell"){
		AddEffect(new LifeEffect());
	}
}
