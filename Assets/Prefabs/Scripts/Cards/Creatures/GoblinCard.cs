using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GoblinCard : CreatureCard {

	public GoblinCard(Transform GoblinSprite) : base(2,"Goblin",2,new List<Effect>(),null){
		this.CardObj = GoblinSprite;
		this.AddEffect(new GoblinBurstEffect());
	}
}
