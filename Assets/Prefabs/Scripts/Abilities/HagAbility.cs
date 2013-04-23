using UnityEngine;
using System.Collections;
/// <summary>
/// Hag ability. Corresponds to gaining +1 quiddity whenever a creature is destroyed
/// and the hag is in your ready area.
/// </summary>
public class HagAbility : Ability {

	public int QuiddityGained { get; set; }
	//not sure how to encode the ready area requirement
	public string Area = "Ready";
	
	public HagAbility(int gained) : base("Hag"){
		this.QuiddityGained = gained;
	}
	
	public HagAbility() : this(1){
	}
}
