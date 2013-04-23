using UnityEngine;
using System.Collections;

public class WizardDoubleEffect : MultipleEffect {
	
	public WizardDoubleEffect() : base("WizardDouble"){
		this.addEffect(new GainGloryEffect(1));
		this.addEffect(new DefenseEffect(1));
	}
}
