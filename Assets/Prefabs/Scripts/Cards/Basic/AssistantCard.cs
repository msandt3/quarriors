using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AssistantCard : CreatureCard {
	
	
	public AssistantCard(Transform AssistantSprite) : base(1,"Assistant",1,new List<Effect>(),null){
		this.CardObj = AssistantSprite;
		base.Effects.Add(new Reroll());
	}
	public AssistantCard() : this(null){
		
	}
}
