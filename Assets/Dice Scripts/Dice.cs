using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Dice {
	
	
	public string diceName{get; set;}
	public Side[] sides;
	public int baseDieUtility{get; set;}
	public int currentSide{get; set;}
	public Player owner{get; set;}
	public int glory{get; set;}
	public GameObject gameObj{get; set;}
	
	public Dice(string name){
		diceName=name;
		sides = new Side[6];
		currentSide = 0;
		owner = null;
	}
	
	public Dice():this(""){}
	
	
	
	
	public void RollDie(){
		currentSide =(int) Mathf.Round((Random.value*5)+1);
	}
	
	public int getBaseDieUtility(){
		//TODO
		return 0;
	}
	
	public List<Effect> GetEffectsForTiming(int timing){
		return sides[currentSide].GetEffectsForTiming(timing);
	}

}
