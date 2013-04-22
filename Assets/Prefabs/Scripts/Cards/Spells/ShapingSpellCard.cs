using UnityEngine;
using System.Collections;

public class ShapingSpellCard : SpellCard {

	public ShapingSpellCard(Transform ShapingSprite) : base(4,"ShapingSpell"){
		this.CardObj = ShapingSprite;
		AddEffect(new ShapingEffect());
	}
	
	public ShapingSpellCard() : this(null){
	}
}
