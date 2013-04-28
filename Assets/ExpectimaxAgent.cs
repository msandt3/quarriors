using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ExpectimaxAgent {
	
	public float EvaluationFunction(Game GameState){
		
		float enemy_ex_glory = GameState.p1.GetExpectedGlory();
		float enemy_ex_attack = GameState.p1.GetExpectedAttack();
		float enemy_ex_defense = GameState.p1.GetExpectedDefense();
		
		//for the following values -- positive is good
		float diff_ex_glory = GameState.p2.GetExpectedGlory() - enemy_ex_glory;
		//high values indicate that we can overwhelm our opponents attack or defense values
		float ex_damage_taken = GameState.p2.GetExpectedDefense() - enemy_ex_attack;
		float ex_damage_dealt = GameState.p2.GetExpectedAttack() - enemy_ex_defense;
		
		//if this is high we have a greater shot at winning
		float diff_glory = GameState.p2.Glory - GameState.p1.Glory;
		
		return diff_ex_glory + (ex_damage_dealt/ex_damage_taken) * diff_glory;
	}
}
