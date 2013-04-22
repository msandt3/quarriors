using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Wilds {
	
	public Basic BasicPile { get; set; }
	public Spells SpellPile { get; set; }
	public Creatures CreaturePile { get; set; }
	
	public Wilds(){
		this.BasicPile = new Basic();
		this.SpellPile = new Spells();
		this.CreaturePile = new Creatures();
	}
	
	public Wilds(GameObject BasicContainer){
		this.BasicPile = new Basic(BasicContainer);
	}
	public Wilds(GameObject BasicContainer, GameObject SpellContainer){
		this.BasicPile = new Basic(BasicContainer);
		this.SpellPile = new Spells(SpellContainer);
	}
}
