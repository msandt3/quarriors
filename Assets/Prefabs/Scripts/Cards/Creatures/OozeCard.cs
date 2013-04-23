using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OozeCard : CreatureCard {
	
	public OozeCard(Transform OozeSprite) : base(8,"Ooze",2,null,new List<Ability>()){
		this.CardObj = OozeSprite;
		this.AddAbility(new SetDefense());
	}
}
