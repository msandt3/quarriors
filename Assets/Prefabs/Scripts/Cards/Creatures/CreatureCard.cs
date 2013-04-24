using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreatureCard : Card{
	
	public int Glory { get; set; }
	
	public CreatureCard(int cost, string name, int glory, 
		List<Effect> effects, List<Ability> abilities) : base(cost,name,effects,abilities){
		this.Glory = glory;
	}	
	
	public CreatureCard(int glory) : this(0,"",glory,null,null){
	}
	
	public CreatureCard(int glory, List<Effect> effects) : this(0,"",glory,effects,null){
	}
	
	public CreatureCard(int glory, List<Ability> abilities) : this(0,"",glory,null,abilities){
	}
	
	public CreatureCard(int glory, List<Effect> effects, List<Ability> abilities) : this(0,"",glory,effects,abilities){
	}
}