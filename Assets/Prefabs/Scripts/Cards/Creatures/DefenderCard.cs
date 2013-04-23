using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DefenderCard : CreatureCard {
	
	public DefenderCard(Transform DefenderSprite) : base(5,"Defender",2,new List<Effect>(),null){
		this.CardObj = DefenderSprite;
		this.Effects.Add(new DefenderBurstEffect());
	}
	
	public DefenderCard() : this(null){
	}
	
}
