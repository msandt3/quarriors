using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WarriorCard : CreatureCard {
	
	public WarriorCard(Transform WarriorSprite) : base(4,"Warrior",2,null,new List<Ability>()){
		this.CardObj = WarriorSprite;
		this.AddAbility(new WarriorAbility());
	}
	
	public WarriorCard() : this(null){
	}
	
}
