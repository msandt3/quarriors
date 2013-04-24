using UnityEngine;
using System.Collections;

public class QuidSide : Side {
	
	public int givenQuiddity{get; set;}
	
	public QuidSide(int givenQuid) : base("QuidSide"){
		givenQuiddity = givenQuid;
		effects[0]= new GainQuiddity(givenQuiddity);	
	}
}
