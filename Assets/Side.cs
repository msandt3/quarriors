using UnityEngine;
using System.Collections;

public class Side {
	
	public int quiddity;
	public int numStars;
	public int creatureCost;
	public int power;
	public int toughness;
	public int glory;
	public int spelltype;
	public int specialID;
	public Die dice;
	
	public Side(int quiddity1, int numStars1, int creatureCost1, int power1, int toughness1, int glory1, 
		int spelltype1, int specialID1, Die dice1) {
		quiddity = quiddity1;
		numStars = numStars1;
		creatureCost = creatureCost1;
		power = power1;
		toughness = toughness1;
		glory = glory1;
		spelltype = spelltype1;
		specialID = specialID1;
		dice = dice1;
	}
	
	public Side() {}
	
}
