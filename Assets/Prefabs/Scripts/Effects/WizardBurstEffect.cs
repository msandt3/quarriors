using UnityEngine;
using System.Collections;

public class WizardBurstEffect : BurstEffect {
	
	public WizardBurstEffect() : base("Wizard"){
		this.Combined = true;
		this.addEffect(new WizardSingleEffect());
		this.addEffect(new WizardDoubleEffect());		
	}
}
