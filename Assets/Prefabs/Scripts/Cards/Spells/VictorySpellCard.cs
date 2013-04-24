using UnityEngine;
using System.Collections;

public class VictorySpellCard : SpellCard {
	
	public VictorySpellCard() : base(9,"VictorySpell"){
		AddAbility(new VictoryAbility());
	}
}
