using UnityEngine;
using System.Collections;

public class GrowthSpellCard : SpellCard {

	public GrowthSpellCard() : base(5,"GrowthSpell"){
		AddEffect(new GrowthEffect());
	}
}
