using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DevoteeCard : CreatureCard {
	
	public DevoteeCard(Transform DevoteeSprite) : base(3,"Devotee",2,new List<Effect>(),null){
		this.CardObj = DevoteeSprite;
		this.AddEffect(new DevoteeBurstEffect());
	}
}
