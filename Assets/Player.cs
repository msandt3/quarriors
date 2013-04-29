using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player{
	
	public int Glory { get; set; }
	public int ActiveQuid { get; set; }
	public List<Die> Bag;
	public List<Die> ActivePool;
	public List<Die> ReadyArea;
	public List<Die> SpentPile;
	public List<Die> UsedPile;
	public List<Die> SummonedCreatures;
	public bool HasCreatures;
	public List<string> tags;
	public Dictionary<string,int> cardCosts;
	public string[] cards = { "BQ", "A", "P", "WH", "SG", "GS", "DHQ", "PO","WQ","QD","DD","QW","DP","S","G","D","V","L"};
	
	//need to enumerate the available actions somehow
	
	
	
	
	
	public Player() {
		cardCosts = new Dictionary<string,int>();
		AddDie ();
		HasCreatures = false;
		tags = new List<string>();
		tags.AddRange (cards);
		Glory = 0;
		Bag = new List<Die>();
		ActivePool = new List<Die>();
		ReadyArea = new List<Die>();
		SpentPile = new List<Die>();
		UsedPile = new List<Die>();
		SummonedCreatures = new List<Die>();
		for (int i = 0; i < 8; i++) {
			Bag.Add (new Die("BQ"));
		}
		for (int i = 0; i < 4; i++) {
			Bag.Add (new Die("A"));
		}
	}
	
	void Shuffle(List<Die> list) {
		Die temp;
		for (int i = list.Count - 1; i > 0; i--) {
			int j = Random.Range(0,i+1);
			temp = list[j];
			list[j] = list[i];
			list[i] = temp;
		}
	}
	
	void BagtoActive(int times) {
		Shuffle (Bag);
		for (int i = 0; i < times; i++){
			if (Bag.Count != 0) {
				Bag[0].roll();
				ActivePool.Add (Bag[0]);
				Bag.RemoveAt (0);
			}
			else {
				UsedtoBag ();
				Shuffle(Bag);
				Bag[0].roll ();
				ActivePool.Add (Bag[0]);
				Bag.RemoveAt (0);
			}
		}
	}
	
	public void DrawAndRoll(){
		BagtoActive(6);
	}
	
	public void SpellstoReady(){
		foreach(Die d in ActivePool){
			if(d.IsActiveSpell()){
				ReadyArea.Add(d);
				ActivePool.Remove(d);
			}
		}
		
	}
	
	void UsedtoBag() {
		Shuffle (UsedPile);
		Bag.AddRange (UsedPile);
		UsedPile.Clear();
	}
	
	void ActivetoReady(int index) {
		ReadyArea.Add (ActivePool[index]);
		ActivePool.RemoveAt(index);
	}
	
	void ActiveToReady(Die d){
		ReadyArea.Add (d);
		ActivePool.Remove(d);
	}
	
	void ActivetoUsed(int index) {
		UsedPile.Add(ActivePool[index]);
		ActivePool.RemoveAt (index);
	}
	
	void ReadytoUsed(int index) {
		UsedPile.Add (ActivePool[index]);
		ActivePool.RemoveAt (index);
	}
	
	public void AllActiveToUsed(){
		foreach(Die d in ActivePool){
			UsedPile.Add(d);
			ActivePool.Remove(d);
		}
	}
	
	void AddDie() {
		cardCosts.Add ("BQ", 0);
		cardCosts.Add ("A", 1);
		cardCosts.Add ("P", 4);
		cardCosts.Add ("WH", 5);
		cardCosts.Add ("SG", 2);
		cardCosts.Add ("GS", 3);
		cardCosts.Add ("DHQ", 3);
		cardCosts.Add ("PO", 8);
		cardCosts.Add ("WQ", 4);
		cardCosts.Add ("QD", 8);
		cardCosts.Add ("DD", 3);
		cardCosts.Add ("QW", 7);
		cardCosts.Add ("DP", 5);
		cardCosts.Add ("S", 3);
		cardCosts.Add ("G", 4);
		cardCosts.Add ("D", 6);
		cardCosts.Add ("V", 7);
		cardCosts.Add ("L", 4);
	}
	
	public void ScoreCreatures(){
		foreach(Die d in ReadyArea){
			Glory += d.ActiveSide.glory;
		}
	}

	public void UpdateQuiddity(){
		foreach(Die d in ActivePool){
			ActiveQuid += d.ActiveSide.quiddity;
		}
	}

	public void SpentToUsed(){
		foreach(Die d in ActivePool){
			if(d.Spent){
				UsedPile.Add(d);
				ActivePool.Remove(d);
				d.Spent = false;
			}
		}
	}

	public int TotalAttack(){
		int ret = 0;
		foreach(Die d in ReadyArea){
			ret += d.ActiveSide.power;
		}
		return ret;
	}

	public int NumCreaturesReady(){
		int ret = 0;
		foreach(Die d in ReadyArea){
			if(d.IsActiveCreature()){
				ret++;
			}
		}
		return ret;
	}
	
	public void AddBoughtDie(Die d){
		this.UsedPile.Add(d);
	}
	
	public void CullDie(Die d){
		this.UsedPile.Remove(d);
	}
	
	/// <summary>
	/// Gets the expected glory.
	/// </summary>
	/// <returns>
	/// The expected glory of all creatures in the 'deck' of this player
	/// </returns>
	public float GetExpectedGlory(){
		int totalglory = 0;
		int totaldice = 0;
		totaldice += Bag.Count;
		//dice in the bag
		foreach(Die d in Bag){
			totalglory += d.GetMaxGlory();
		}
		totaldice += ActivePool.Count;
		foreach(Die d in ActivePool){
			totalglory += d.GetMaxGlory();
		}
		totaldice += UsedPile.Count;
		foreach(Die d in UsedPile){
			totalglory += d.GetMaxGlory();
		}
		totaldice += ReadyArea.Count;
		foreach(Die d in ReadyArea){
			totalglory += d.GetMaxGlory();
		}
		totaldice += SpentPile.Count;
		foreach(Die d in SpentPile){
			totalglory += d.GetMaxGlory();
		}
		
		return (float)totalglory/(float)totaldice;
	}
	
	
	public float GetExpectedAttack(){
		int totalattack = 0;
		int totaldice = 0;
		totaldice += Bag.Count;
		//dice in the bag
		foreach(Die d in Bag){
			totalattack += d.GetMaxAttack();
		}
		totaldice += ActivePool.Count;
		foreach(Die d in ActivePool){
			totalattack += d.GetMaxAttack();
		}
		totaldice += UsedPile.Count;
		foreach(Die d in UsedPile){
			totalattack += d.GetMaxAttack();
		}
		totaldice += ReadyArea.Count;
		foreach(Die d in ReadyArea){
			totalattack += d.GetMaxAttack();
		}
		totaldice += SpentPile.Count;
		foreach(Die d in SpentPile){
			totalattack += d.GetMaxAttack();
		}
		
		return (float)totalattack/(float)totaldice;
	}
	
	public float GetExpectedDefense(){
		int totaldef = 0;
		int totaldice = 0;
		totaldice += Bag.Count;
		//dice in the bag
		foreach(Die d in Bag){
			totaldef += d.GetMaxDefense();
		}
		totaldice += ActivePool.Count;
		foreach(Die d in ActivePool){
			totaldef += d.GetMaxDefense();
		}
		totaldice += UsedPile.Count;
		foreach(Die d in UsedPile){
			totaldef += d.GetMaxDefense();
		}
		totaldice += ReadyArea.Count;
		foreach(Die d in ReadyArea){
			totaldef += d.GetMaxDefense();
		}
		totaldice += SpentPile.Count;
		foreach(Die d in SpentPile){
			totaldef += d.GetMaxDefense();
		}
		
		return (float)totaldef/(float)totaldice;
	}

	public void SummonCreature(string tag){
		//get the die we want to summon
		Die tosummon = null;
		foreach(Die d in ActivePool){
			if(d.tag == tag){
				tosummon = d;
			}
		}
		
		int cost = tosummon.ActiveSide.creatureCost;
		
		if(ActiveQuid >= cost){
			ActiveToReady(tosummon);
			RemoveQuiddity(cost);
		}
	}
	
	public void RemoveQuiddity(int amt){
		
		while(amt > 0){
			Die quid = null;
			
			
			if(amt == 1){
				foreach(Die d in ActivePool){
					if(d.ActiveSide.quiddity == 1){
						quid = null;
						break;
					}
				}
			}
			if(amt == 2){
				foreach(Die d in ActivePool){
					if(d.ActiveSide.quiddity == 2){
						quid = null;
						break;
					}
				}
			}
			else{
				foreach(Die d in ActivePool){
					if(d.ActiveSide.quiddity > 0){
						quid = null;
						break;
					}
				}
			}
			
			amt = amt - quid.ActiveSide.quiddity;
			ActivePool.Remove(quid);
			SpentPile.Add(quid);
			
		}
			
	}
}