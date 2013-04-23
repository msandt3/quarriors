using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HagCard : CreatureCard {
	
	public HagCard(Transform HagSprite) : base(5,"Hag",3,null,new List<Ability>()){
		this.CardObj = HagSprite;
		this.AddAbility(new HagAbility());
	}
}
