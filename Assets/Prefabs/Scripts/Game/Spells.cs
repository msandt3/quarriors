using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spells {
	
	public List<Card> Cards { get; set; }
	
	public Spells(List<Card> cards){
		this.Cards = cards;
	}
	public Spells(){
		this.Cards = null;
	}
	
	public Spells(GameObject SpellSprites){
		this.Cards = new List<Card>();
		
		foreach(Transform child in SpellSprites.transform){
			switch(child.name){
				case("DeathCard(Clone)"):
					Cards.Add(new DeathSpellCard(child));
					break;
				case("GrowthCard(Clone)"):
					Cards.Add (new GrowthSpellCard(child));
					break;
				case("LifeCard(Clone)"):
					Cards.Add(new LifeSpellCard(child));
					break;
				case("ShapingCard(Clone)"):
					Cards.Add(new ShapingSpellCard(child));
					break;
				case("VictoryCard(Clone)"):
					Cards.Add(new VictorySpellCard(child));
					break;
			}
		}
		
		foreach(Card card in Cards){
			Debug.Log(card.Name);
		}
	}
}
