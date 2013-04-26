using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game {
	public List<Card> Cards { get; set; }
	Player p1;
	Player p2;
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
		//either player has 15 glory
		//wilds have four cards without dice
		
		//otherwise
		return false;
	}
	
	
}
