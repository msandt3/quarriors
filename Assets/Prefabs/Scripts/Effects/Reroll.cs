using UnityEngine;
using System.Collections;

public class Reroll : ImmediateEffect {
	
	public int Others { get; set; }
	public bool Required { get; set; }
	
	public Reroll(int numOthers, bool req) : base("Reroll"){
		this.Others = numOthers;
		this.Required = req;
	}
	
	public Reroll(int numOthers) : this(numOthers,true){
	}
	
	public Reroll(bool req) : this(1,req){
	}
	
	public Reroll() : this(1,true){
	}
}
