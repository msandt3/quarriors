using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Card{

	public int DiceRemaining { get; set; }
	public string Name {get; set;}
	
	public Card(int dice, string name){
		this.DiceRemaining = dice;
		this.Name = name;
	}
	public Card(string name) : this(5,name){
	}
	public Card() : this(5,"NULL"){
	}
	
	public string ToString(){
		return this.Name;
	}
		
}
