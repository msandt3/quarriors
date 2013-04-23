using UnityEngine;
using System.Collections;

public class GainGloryEffect : Effect {
	
	public int GloryGained { get; set; }
	
	public GainGloryEffect(int glory) : base("GainGlory"){
		this.GloryGained = glory;
		this.OnScore = true;
	}
	
	public GainGloryEffect() : this(1){
	}
}
