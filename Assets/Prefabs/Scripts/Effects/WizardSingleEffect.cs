using UnityEngine;
using System.Collections;

public class WizardSingleEffect : MultipleEffect {
	
	public WizardSingleEffect() : base("WizardSingle"){
		this.addEffect(new DrawAndRoll(1));
		this.addEffect(new Reroll(0,true));
	}
}
