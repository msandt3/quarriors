using UnityEngine;
using System.Collections;

public class ReactionEffect : Effect {
	//again not sure if we'll need this --- might be better fit in Dice class
	public Object AttachedTo { get; set; }

	public ReactionEffect(string name) : base(name){
		this.AttachedTo = null;
	}
	
	public ReactionEffect() : this(""){
	}
	
	public void AttachTo(Object obj){
		this.AttachedTo = obj;
	}
}
