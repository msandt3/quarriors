using UnityEngine;
using System.Collections;
//represents class for reducing desired creature's attack
public class LifeEffect : ReactionEffect {
	//damage value the creature's attack will be reduced to
	public int ReducedTo { get; set; }
	
	public LifeEffect() : base("Life"){
		this.ReducedTo = 0;
	}

}
