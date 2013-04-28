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
	public List<Side> SummonedCreatures;
	public bool HasCreatures;
	public List<string> tags;
	public Dictionary<string,int> cardCosts;
	public string[] cards = { "BQ", "A", "P", "WH", "SG", "GS", "DHQ", "PO","WQ","QD","DD","QW","DP","S","G","D","V","L"};
	
	
	
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
	
	public int ScoreCreatures(){
		int i = 0;
		foreach(Die d in ReadyArea){
			Glory += d.ActiveSide.glory;
			if (d.ActiveSide.glory > 0) {
				i++;
			}
		}
		return i;
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
		
}
