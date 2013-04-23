using UnityEngine;
using System.Collections;

public class CombinedBurstEffect : BurstEffect {
	
	public CombinedBurstEffect(string name) : base(name){
		this.Combined = true;
	}
	
	public CombinedBurstEffect() : this(""){
	}
}
