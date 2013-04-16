using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BurstEffect : Effect {
	
	public bool Combined { get; set; }
	//maintain a list of the effects - just need one reference
	//to access all effects therein
	public List<Effect> Bursts { get; set; }
	//index 0 for first burst -- index 1 for second
	
	public BurstEffect(string name, bool comb) : base(name){
		this.Combined = false;
		this.Bursts = null;
	}
	
	public BurstEffect(string name) : this(name,false){
	}
	
	public BurstEffect() : this("",false){
	}
	
	public void addEffect(Effect eff){
		if(Bursts == null){
			this.Bursts = new List<Effect>();
			this.Bursts.Add(eff);
		}
		else{
			this.Bursts.Add (eff);
		}
	}
	
	public void setCombined(bool comb){
		this.Combined = comb;
	}
}
