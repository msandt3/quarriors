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
}
