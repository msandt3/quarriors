using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PortalCard : Card {
	
	public PortalCard(Transform PortalSprite) : base(4,"Portal",new List<Effect>(),null){
		this.CardObj = PortalSprite;
		base.Effects.Add(new DrawAndRoll(1));
		base.Effects.Add(new DrawAndRoll(2));
	}
	
	public PortalCard() : this(null){
	}
}
