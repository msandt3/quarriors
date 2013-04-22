using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// Container class for Basic Cards
/// </summary>
public class Basic{
	
	public List<Card> Cards { get; set; }
	
	public Basic(List<Card> cards){
		this.Cards = cards;
	}
	public Basic(){
		this.Cards = new List<Card>();
		Cards.Add (new AssistantCard());
		Cards.Add (new PortalCard());
		Cards.Add (new QuiddityCard());
	}
	
	public Basic(GameObject BasicSprites){
		this.Cards = new List<Card>();
		Transform assistantsprite = BasicSprites.transform.Find("AssistantCard");
		Transform portalsprite = BasicSprites.transform.Find ("PortalCard");
		Transform quidditysprite = BasicSprites.transform.Find ("QuiddityCard");
		Cards.Add (new AssistantCard(assistantsprite));
		Cards.Add (new PortalCard(portalsprite));
		Cards.Add (new QuiddityCard(quidditysprite));
	}
	
}