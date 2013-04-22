using UnityEngine;
using System.Collections;

public class QuiddityCard : Card {
	
	
	public QuiddityCard(Transform QuidditySprite) : base(0,"Quiddity",null,null){
		this.CardObj = QuidditySprite;
	}
	public QuiddityCard() : this(null){
	}
	
	
}
