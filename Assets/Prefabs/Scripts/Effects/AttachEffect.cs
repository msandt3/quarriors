using UnityEngine;
using System.Collections;

public class AttachEffect : Effect {
	
	//not sure if we'll need this
	public Object AttachedTo { get; set; }
	
	public AttachEffect(string name) : base(name){
		this.AttachedTo = null;
	}
	
	public AttachEffect() : this(""){
	}
}
