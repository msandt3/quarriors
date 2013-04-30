using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class QuarriorAgent{
	
	private Game GameState;
	private Player opponent;
	private Player agent;
	
	private int START_EARLY = 0;
	private int START_MID = 6;
	private int START_LATE = 11;
	
	public QuarriorAgent(Game GameState, Player opp, Player me){
		this.GameState = GameState;
		this.opponent = opp;
		this.agent = me;
	}
	
	public List<Die> CullAction(int numscored, int turn){
		List<Die> ret = new List<Die>();
		while(numscored > 0){
			//early game
			Die d;
			if(turn < START_MID){
				if(agent.AverageQuiddity() > 8){
					if(CullQuiddity() != null){
						d = CullQuiddity();
						agent.CullDie(d);
						GameState.CullDie(d);
						ret.Add(d);
					}
					else if(CullAssistant() != null){
						d = CullAssistant();
						agent.CullDie(d);
						GameState.CullDie(d);
						ret.Add(d);
					}
					else{
						Debug.Log("nothing culled");
					}
				}
			}
			//mid game
			else if(turn < START_LATE){
				if(agent.AverageQuiddity() > 10){
					if(CullQuiddity() != null){
						d = CullQuiddity();
						agent.CullDie(d);
						GameState.CullDie(d);
						ret.Add(d);
					}
					else if(CullAssistant() != null){
						d = CullAssistant();
						agent.CullDie(d);
						GameState.CullDie(d);
						ret.Add(d);
					}
					else{
						Debug.Log("nothing culled");
					}
				}
			}
			//late game
			else{
				if(agent.AverageQuiddity() > 8){
					if(CullQuiddity() != null){
						d = CullQuiddity();
						agent.CullDie(d);
						GameState.CullDie(d);
						ret.Add(d);
					}
					else if(CullAssistant() != null){
						d = CullAssistant();
						agent.CullDie(d);
						GameState.CullDie(d);
						ret.Add(d);
					}
					else{
						Debug.Log("nothing culled");
					}
				}
			}
		numscored--;
		}
		return ret;
	}
	
	private Die CullQuiddity(){
		Die quid = null;
		for(int i=0; i<agent.UsedPile.Count; i++){
			if(agent.UsedPile[i].tag == "Q"){
				quid = agent.UsedPile[i];
				return quid;
			}
		}
		return quid;
	}
	
	private Die CullAssistant(){
		Die ass = null;
		for(int i=0; i<agent.UsedPile.Count; i++){
			if(agent.UsedPile[i].tag == "A"){
				ass = agent.UsedPile[i];
				return ass;
			}
		}
		return ass;
	}
	
	public List<Die> SummonAction(int turn, List<Die> wilds){
		List<Die> ret = new List<Die>();
		do{
			Die summonchoice = GetBestSummonable();
			Die buychoice = GetBestToBuy(wilds);
			//if we have no die to summon -- break
			if(summonchoice == null){
				break;
			}			
			float combined = SummonValue(summonchoice) + BuyValue(buychoice);
			//if buying outweighs everything break
			if(BuyValue(buychoice) > combined){
				break;
			}
			//otherwise add the die to the return list & summon it
			else{
				ret.Add (summonchoice);
				agent.SummonDie(summonchoice);
			}
		}while(agent.ActiveQuid > 0 && agent.ActivePool.Count > 0);
		//prompt agent for creature to summon
		//while quid > 0 && it hasnt decided to buy
	}
	
	public Die GetBestSummonable(){
		Die ret = null;
		float best = Mathf.NegativeInfinity;
		for(int i=0; i<agent.ActivePool.Count; i++){
			if(agent.ActivePool[i].IsActiveCreature() && agent.ActiveQuid >= agent.ActivePool[i].ActiveSide.creatureCost){
				if(SummonValue(agent.ActivePool[i]) > best){
					best = SummonValue(agent.ActivePool[i]);
					ret = agent.ActivePool[i];
				}
			}
		}
		return ret;
	}
	
	public Die GetBestToBuy(List<Die> wilds){
		Die ret = null;
		float best = Mathf.NegativeInfinity;
		for(int i=0; i<wilds.Count; i++){
			if(wilds[i].IsCreature() && agent.ActiveQuid >= wilds[i].cost){
				if(BuyValue(wilds[i]) > best){
					best = BuyValue(wilds[i]);
					ret = agent.ActivePool[i];
				}
			}
		}
		return ret;
	}
	public float SummonValue(Die d){
		return 2f * (1f - opponent.ProbRollingDieToKill(d));	
	}
	
	public float BuyValue(Die d){
		float defprob = 1f - opponent.ProbRollingDieToKill(d);
		float attprob = opponent.ProbGettingKilledBy(d);
		
		return (d.averageGlory()/(float) d.cost) * ((defprob + attprob)/2f);
	}

	public Die BuyAction(List<Die> wilds){
		Die tobuy = GetBestToBuy(wilds);
		GameState.BuyDie(tobuy);
		agent.BuyDie(tobuy);
		return tobuy;
	}
	
	public List<Die> DefendOrder(int attack){
		
	}
}
