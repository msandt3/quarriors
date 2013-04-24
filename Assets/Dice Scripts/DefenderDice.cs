using UnityEngine;
using System.Collections;

public class DefenderDice : CreatureDice {

	public DefenderDice() : base("Defender of the Pale"){
		sides[0]= new QuidSide(1);
		sides[1]= new QuidSide(2);
		sides[2]= new QuidSide(2);
		sides[3]= new DefenderSide(1,5,1,"Defender of the Pale Lv.1");
		sides[4]= new DefenderSide(2,6,2,"Defender of the Pale Lv.2");
		sides[5]= new DefenderSide(2,8,3,"Defender of the Pale Lv.3");
	
	}
	
	public override void OnScore(){
		owner.currentGlory += glory + (owner.readyArea.readyCreatures.Count-1);

	}
	
	public override int OnAttack(){
		return ((DefenderSide)sides[currentSide]).atkPower;
		
	}
	
	
	public override int OnDefend(){
	  	return ((DefenderSide)sides[currentSide]).defPower;
	}
	
	
}
