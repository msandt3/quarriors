using UnityEngine;
using System.Collections;
/// <summary>
/// Represents an ability for destroying all creatures of MaxLevel or less
/// in your opponent's ready area when this creature attacks
/// </summary>
public class DestroyAbility : Ability {

	public bool OnAttack { get; set; }
	public int MaxLevel { get; set; }
	//not sure if we'll need this
	public string Area = "Ready";
	
	public DestroyAbility(int maxlevel) : base("Destroy"){
		this.MaxLevel = maxlevel;
		this.OnAttack = true;
	}
	
	public DestroyAbility() : this(1){
	}
}
