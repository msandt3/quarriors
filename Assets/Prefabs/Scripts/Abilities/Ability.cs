using UnityEngine;
using System.Collections;

public class Ability {
	
	public string Name { get; set; }
	
	public Ability(string name){
		this.Name = name;
	}
	
	public Ability() : this(""){
	}
}
