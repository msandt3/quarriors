using UnityEngine;
using System.Collections;

public class GainQuiddity : ImmediateEffect {

	public int Gained { get; set; }
	
	public GainQuiddity(int num) : base("Gain"){
		this.Gained = num;
	}
	public GainQuiddity() : this(2){
	}
}
