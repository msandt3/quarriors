using UnityEngine;
using System.Collections;
//Adds specified amount of glory to every creature that scores during this turn
public class DefenderGloryEffect : Effect {
	
	public int Glory { get; set; }
	
	public DefenderGloryEffect(int glory) : base("Defender"){
		this.OnScore = true;
		this.Glory = glory;
	}
	
	public DefenderGloryEffect() : this(1){
	}
}
