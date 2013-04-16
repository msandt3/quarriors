using UnityEngine;
using System.Collections;

public class VictoryAbility : Ability {
	
	public int Glory { get; set; }
	
	public VictoryAbility(int glory) : base("Victory"){
		this.Glory = glory;
	}
	
	public VictoryAbility() : this(3){
	}
}
