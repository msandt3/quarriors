using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AssitantCard : CreatureCard {

	public AssitantCard() : base(1,"Assistant",1,new List<Effect>(),null){
		base.Effects.Add(new Reroll());
	}
}
