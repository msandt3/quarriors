using UnityEngine;
using System.Collections;

public class ShapingEffect : AttachEffect {

	public Object CulledDie { get; set; }
	public int Plus { get; set; }
	
	public ShapingEffect(int numplus) : base("Shaping"){
		this.CulledDie = null;
		this.Plus = numplus;
	}
	
	public ShapingEffect() : this(3){
	}
}
