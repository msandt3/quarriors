using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PortalCard : Card {
	
	public PortalCard() : base(4,"Portal",new List<Effect>(),null){
		base.Effects.Add(new DrawAndRoll(1));
		base.Effects.Add(new DrawAndRoll(2));
	}
}
