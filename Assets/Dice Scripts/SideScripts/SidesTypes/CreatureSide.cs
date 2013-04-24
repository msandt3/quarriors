using UnityEngine;
using System.Collections;

public class CreatureSide : Side{
	
	public int atkPower{get; set;}
	public int defPower{get; set;}
	public int summonCost{get; set;}
	
	// Use this for initialization
	
	public CreatureSide(int atk, int def, int cost, string name): base(name){
		atkPower=atk;
		defPower=def;
		summonCost=cost;
		
	}
	
}
