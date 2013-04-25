using UnityEngine;
using System.Collections;

public class Game {
	
	Player p1;
	Player p2;
	private int turn;
	private int phase;
	
	public Game() {
		p1 = new Player();
		p2 = new Player();
		turn = 1;
		phase = 1;
	}
	
}
