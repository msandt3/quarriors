using UnityEngine;
using System.Collections;

public class TradeAbility : Ability {

	public bool Any { get; set; }
	
	public TradeAbility() : base("Trade"){
		this.Any = true;
	}
}
