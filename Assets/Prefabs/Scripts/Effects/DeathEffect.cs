using UnityEngine;
using System.Collections;
//Represents an effect for destroying a creature
public class DeathEffect : Effect {
	
	//max level creature to be affected
	public int MaxLevel { get; set; }
	
	public DeathEffect(int level) : base("Death"){
		this.MaxLevel = level;
	}
}
