using UnityEngine;
using System.Collections;

public class DefenderSide : CreatureSide {

	public DefenderSide(int atk, int def, int cost, string name): base(atk,def,cost,name){
		effects.Add(new GainGloryEffect(Effect.TIMING_ONSCORE, 0));
	}
	
}

