using UnityEngine;
using System.Collections;

public class WizardCard : CreatureCard {

	public WizardCard(Transform WizardSprite) : base(7,"Wizard",3,null,null){
		this.CardObj = WizardSprite;
		this.AddEffect(new WizardBurstEffect());
	}
	public WizardCard() : this(null){
	}
}
