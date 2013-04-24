using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Side{
	//This class is primarily for data storage...all sides will have thier own dice.
	
	public string name{get; set;}
	public List<Effect> effects;
	public Texture2D sideTexture{get; set;}
	bool isReady{get; set;}
	
	
	public Side(string name){
		this.name=name;
		effects = new List<Effect>();
		isReady=false;
	}
	
	public List<Effect> GetEffectsForTiming(int timing){
		List<Effect> returnedEffects = new List<Effect>();
		for(int i=0; i<effects.Count;i++){
			if(effects[i].timing==timing){
				returnedEffects.Add(effects[i]);
				
			}
			
		}
		return returnedEffects;	
	}

}
