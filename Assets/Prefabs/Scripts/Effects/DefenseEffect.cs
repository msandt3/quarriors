using UnityEngine;
using System.Collections;

public class DefenseEffect : Effect {
	
	public int DefenseGain { get; set; }
	
	public DefenseEffect(int gain) : base("Defense"){
		DefenseGain = gain;
	}
	public DefenseEffect() : this(2){
	}
}
