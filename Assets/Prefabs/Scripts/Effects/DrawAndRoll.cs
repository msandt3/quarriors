using UnityEngine;
using System.Collections;

public class DrawAndRoll : ImmediateEffect {
	
	public int ToDraw { get; set; }
	
	public DrawAndRoll(int num) : base("DrawAndRoll"){
		this.ToDraw = num;
	}
	
	public DrawAndRoll() : this(1){
	}
}
