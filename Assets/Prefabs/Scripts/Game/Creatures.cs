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
}
