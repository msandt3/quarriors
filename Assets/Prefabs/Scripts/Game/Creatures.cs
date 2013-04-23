using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Creatures {
	
	public List<Card> Cards { get; set; }
	
	public Creatures(List<Card> cards){
		this.Cards = cards;
	}
	public Creatures(){
		this.Cards = null;
	}
	
	public Creatures(GameObject CreatureSprites){
		this.Cards = new List<Card>();
		foreach(Transform child in CreatureSprites.transform){
			switch(child.name){
				case("DeathDealerCard(Clone)"):
					Cards.Add(new DeathDealerCard(child));
					break;
				case("DefenderCard(Clone)"):
					Cards.Add (new DefenderCard(child));
					break;
				case("DevoteeCard(Clone)"):
					Cards.Add(new DevoteeCard(child));
					break;
				case("DragonCard(Clone)"):
					Cards.Add(new DragonCard(child));
					break;
				case("GoblinCard(Clone)"):
					Cards.Add(new GoblinCard(child));
					break;
				case("HagCard(Clone)"):
					Cards.Add(new HagCard(child));
					break;
				case("OozeCard(Clone)"):
					Cards.Add(new OozeCard(child));
					break;
				case("SpiritCard(Clone)"):
					//TODO - implement spirit card stuff
					//Cards.Add(new HagCard(child));
					break;
				case("WarriorCard(Clone)"):
					Cards.Add(new WarriorCard(child));
					break;
				case("WizardCard(Clone)"):
					Cards.Add(new WizardCard(child));
					break;
			}
		}
	}
}
