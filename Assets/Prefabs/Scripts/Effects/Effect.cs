using UnityEngine;
using System.Collections;

public class Effect{
	
	public string Name { get; set; }
	public bool OnScore { get; set; }
	public Effect(string name){
		this.Name = name;
		this.OnScore = false;
	}
	
	public Effect() : this(""){
	}
}
