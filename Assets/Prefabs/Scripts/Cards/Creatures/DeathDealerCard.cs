using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DeathDealerCard : CreatureCard {

	public DeathDealerCard(Transform DeathSprite) : base(3,"DeathDealer",2,null,new List<Ability>()){
		this.CardObj = DeathSprite;
		this.Abilities.Add(new TradeAbility());
	}
}
