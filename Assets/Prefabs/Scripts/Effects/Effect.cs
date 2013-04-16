using UnityEngine;
using System.Collections;

public class Effect{
	
	public string Name { get; set; }
	
	public Effect(string name){
		this.Name = name;
	}
	
	public Effect() : this(""){
	}
}
