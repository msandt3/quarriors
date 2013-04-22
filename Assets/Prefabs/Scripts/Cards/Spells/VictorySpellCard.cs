using UnityEngine;
using System.Collections;

public class VictorySpellCard : SpellCard {
	
	public VictorySpellCard(Transform VictorySprite) : base(9,"VictorySpell"){
		this.CardObj = VictorySprite;
		AddAbility(new VictoryAbility());
	}
	
	public VictorySpellCard() : this(null){
	}
}
