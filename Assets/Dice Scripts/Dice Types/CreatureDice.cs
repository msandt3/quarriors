using UnityEngine;
using System.Collections;

public abstract class CreatureDice : Dice{
	
	public CreatureDice(string name) : base(name){}
	public CreatureDice() : this(""){}

	public abstract void OnScore();
	public abstract int OnAttack();
	public abstract int OnDefend();
}
