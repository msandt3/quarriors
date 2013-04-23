using UnityEngine;
using System.Collections;
/// <summary>
/// Set defense. This corresponds to setting the defense of said creature
/// to the number of quiddity in your used & active piles combined.
/// </summary>
public class SetDefense : Ability {
	
	public int ModifiedDefense { get; set; }
	
	public SetDefense() : base("SetDefense"){
		//not sure how to encode this either -- need ready area structure first
		this.ModifiedDefense = 2;
	}
}
