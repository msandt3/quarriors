using UnityEngine;
using System.Collections;

public class Effect{
	
	public static int TIMING_ONSCORE=0;
	public static int TIMING_ONSUMMON=1;
	public static int TIMING_IMMEDIATE=2;
	
	public int timing { get; set; }
	
	public string Name { get; set; }
	public bool OnScore { get; set; }
	public Effect(string name){
		this.Name = name;
		this.OnScore = false;
		this.timing = TIMING_IMMEDIATE;
	}
	
	public Effect() : this(""){
	}
	
	public Effect(string name,int timing){
		this.Name = name;
		this.OnScore = false;
		this.timing = timing;
	}
}
