using UnityEngine;
using System.Collections;

public class LifeSpellCard : SpellCard {
	
	
	public LifeSpellCard(Transform LifeSprite) : base(4,"LifeSpell"){
		this.CardObj = LifeSprite;
		AddEffect(new LifeEffect());
	}
	public LifeSpellCard() : this(null){
	}
}
