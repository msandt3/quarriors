using UnityEngine;
using System.Collections;

public class ShapingSpellCard : SpellCard {

	public ShapingSpellCard() : base(4,"ShapingSpell"){
		AddEffect(new ShapingEffect());
	}
}
