using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DragonCard : CreatureCard {
	
	public DragonCard(Transform DragonSprite) : base(8,"Dragon",4,null,new List<Ability>()){
		this.CardObj = DragonSprite;
		this.AddAbility(new DestroyAbility());
	}
	
	public DragonCard() : this(null){
	}

}
