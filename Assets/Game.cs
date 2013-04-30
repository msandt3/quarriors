using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game {
	public List<Card> Cards { get; set; }
	public Player p1 { get; set; }
	public Player p2 { get; set; }
	private int turn;
	private int phase;
	
	
	
	public Game() {
		Cards = new List<Card>();
		p1 = new Player();
		p2 = new Player();
		turn = 1;
		phase = 1;
	}
	
	public bool isWin(){
		if(p1.Glory == 16 || p2.Glory == 16){
			return true;
		}
		else
			return false;
	}
	
	public Die BuyDie(Die d){
		foreach(Card card in Cards){
			if(card.Name == d.tag){
				card.DiceRemaining--;
				break;
			}
		}
		Die newDie = new Die(d.tag);
		return newDie;
	}
	
	public void CullDie(Die d){
		foreach(Card card in Cards){
			if(card.Name == d.tag){
				card.DiceRemaining++;
			}
		}
	}
	
	
}
