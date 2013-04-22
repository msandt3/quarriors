using UnityEngine;
using System.Collections;

public class GrowthSpellCard : SpellCard {

	public GrowthSpellCard(Transform GrowthSprite) : base(5,"GrowthSpell"){
		this.CardObj = GrowthSprite;
		AddEffect(new GrowthEffect());
	}
	
	public GrowthSpellCard() : this(null){
	}
}
