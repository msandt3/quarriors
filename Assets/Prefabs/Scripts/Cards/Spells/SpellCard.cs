using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpellCard : Card {
	
	public SpellCard(int cost, string name, List<Effect> effects, List<Ability> abilities) : base(cost,name,effects,abilities){
	}
	public SpellCard() : this(0,"",null,null){
	}
	
	public SpellCard(int cost) : this(cost,"",null,null){
	}
	
	public SpellCard(string name) : this(0,name,null,null){
	}
	
	public SpellCard(int cost, string name) : this(cost, name, null, null){
	}
	
	public SpellCard(int cost, string name, List<Effect> effects) : this(cost,name,effects,null){
	}
	
	public SpellCard(int cost, string name, List<Ability> abilities) : this(cost,name,null,abilities){
	}
}
