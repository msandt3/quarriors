using UnityEngine;
using System.Collections;
/// <summary>
/// Warrior ability. Gains x amount attack given defending player has y creatures in ready area
/// </summary>
public class WarriorAbility : Ability {
	
	public int AttackGained { get; set; }
	public int MaxReady { get; set; }
	
	public WarriorAbility(int attack, int ready) : base("Warrior"){
		this.AttackGained = attack;
		this.MaxReady = ready;
	}
	
	public WarriorAbility() : this(3,1){
	}
}
