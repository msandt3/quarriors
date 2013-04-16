using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Card{

	public int Cost { get; set; }
	public string Name {get; set;}
	public List<Effect> Effects { get; set; }
	public List<Ability> Abilities { get; set; }
	
	public Card(int cost, string name, List<Effect> effects, List<Ability> abilities){
		this.Cost = cost;
		this.Name = name;
		this.Effects = effects;
		this.Abilities = abilities;
	}
	
	public Card() : this(0,"",null,null){
	}
	
	public Card(int cost) : this(cost,"",null,null){
	}
	
	public Card(string name) : this(0,name,null,null){
	}
	
	public Card(int cost, string name, List<Effect> effects) : this(cost,name,effects,null){
	}
	
	public Card(int cost, string name, List<Ability> abilities) : this(cost,name,null,abilities){
	}
	
	
		
}
