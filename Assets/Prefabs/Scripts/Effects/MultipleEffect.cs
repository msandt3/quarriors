using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MultipleEffect : Effect{

	public List<Effect> Effects { get; set; }
	public bool Multiple { get; set; }
	
	public MultipleEffect(string name) : base(name){
		this.Effects = null;
		this.Multiple = true;
	}
	
	public MultipleEffect() : this("Multiple"){
	}
	
	public void addEffect(Effect eff){
		if(Effects == null){
			Effects = new List<Effect>();
		}
		Effects.Add(eff);
	}
}
