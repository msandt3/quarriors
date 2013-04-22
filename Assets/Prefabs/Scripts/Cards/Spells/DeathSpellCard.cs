using UnityEngine;
using System.Collections;

public class DeathSpellCard : SpellCard {
	
	public DeathSpellCard(Transform DeathSprite) : base(5,"DeathSpell"){
		this.CardObj = DeathSprite;
		AddEffect(new DeathBurstEffect());		
	}
	
	public DeathSpellCard() : this(null){
	}
}
