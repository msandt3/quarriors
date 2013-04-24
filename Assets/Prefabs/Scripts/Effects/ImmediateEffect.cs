using UnityEngine;
using System.Collections;

public class ImmediateEffect : Effect{
	public bool Immediate { get; set; }
	
	public ImmediateEffect(string name) : base(name){
		this.Immediate = true;
	}
	
	public ImmediateEffect() : this(""){
		this.Immediate = true;
	}
}
