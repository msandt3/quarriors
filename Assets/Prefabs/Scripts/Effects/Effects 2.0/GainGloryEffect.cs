using UnityEngine;
using System.Collections;

public class GainGloryEffect : Effect {

	public int Glory { get; set; }
	
	public GainGloryEffect(int timing, int glory): base("GainGlory",timing){
		Glory = glory;
	}
	
	
}
