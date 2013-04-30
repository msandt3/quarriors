using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Die {

	private Side s1;
	private Side s2;
	private Side s3;
	private Side s4;
	private Side s5;
	private Side s6;
	public string tag;
	public List<Side> SideList;
	public bool Spent { get; set; }
	public int cost;
	
	private string[] spelltags = {"S","G","D","V","L"};
	
	public Side ActiveSide { get; set; }
	
	public Die(string label) {
		tag = label;
		SideList = new List<Side>();
		switch(tag)
		{
		case "BQ":
			createBQ ();
			break;
		case "A":
			createA ();
			break;
		case "P":
			createP();
			break;
		case "WH":
			createWH ();
			break;
		case "SG":
			createSG ();
			break;
		case "GS":
			createGS ();
			break;
		case "DHQ":
			createDHQ ();
			break;
		case "PO":
			createPO ();
			break;
		case "WQ":
			createWQ ();
			break;
		case "QD":
			createQD ();
			break;
		case "DD":
			createDD ();
			break;
		case "QW":
			createQW ();
			break;
		case "DP":
			createDP ();
			break;
		case "S":
			createS ();
			break;
		case "G":
			createG ();
			break;
		case "D":
			createD ();
			break;
		case "V":
			createV ();
			break;
		case "L":
			createL ();
			break;
		}

		this.ActiveSide = SideList[0];
		this.Spent = false;
	}
	
	public Side roll() {
		int rand = Random.Range (0,6);
		ActiveSide = SideList[rand];
		return SideList[rand];
	}
	
		
	void createBQ() {
		this.cost = 0;
		SideList.Add (new Side(1,0,0,0,0,0,0,0,-1,this));
		SideList.Add (new Side(1,0,0,0,0,0,0,0,-1,this));
		SideList.Add (new Side(1,0,0,0,0,0,0,0,-1,this));
		SideList.Add (new Side(1,0,0,0,0,0,0,0,-1,this));
		SideList.Add (new Side(1,0,0,0,0,0,0,0,-1,this));
		SideList.Add (new Side(2,0,0,0,0,0,0,0,-1,this));
	}
	
	void createA() {
		this.cost = 1;
		SideList.Add (new Side(1,0,0,0,0,0,0,0,-1,this));
		SideList.Add (new Side(1,0,0,0,0,0,0,0,-1,this));
		SideList.Add (new Side(1,0,0,0,0,0,0,0,-1,this));
		SideList.Add (new Side(0,1,0,0,0,0,0,0,0,this));
		SideList.Add (new Side(0,0,1,1,2,1,0,0,-1,this));
		SideList.Add (new Side(0,0,1,1,2,1,0,0,-1,this));
	}
	
	void createP() {
		this.cost = 4;
		SideList.Add (new Side(1,0,0,0,0,0,0,0,-1,this));
		SideList.Add (new Side(0,0,0,0,0,0,0,0,1,this));
		SideList.Add (new Side(0,0,0,0,0,0,0,0,1,this));
		SideList.Add (new Side(0,0,0,0,0,0,0,0,2,this));
		SideList.Add (new Side(0,0,0,0,0,0,0,0,2,this));
		SideList.Add (new Side(0,0,0,0,0,0,0,0,2,this));
	}
	
	void createWH() {
		this.cost = 5;
		SideList.Add (new Side(1,0,0,0,0,0,0,0,-1,this));
		SideList.Add (new Side(2,0,0,0,0,0,0,0,-1,this));
		SideList.Add (new Side(2,0,0,0,0,0,0,0,-1,this));
		SideList.Add (new Side(0,0,1,3,3,3,0,0,13,this));
		SideList.Add (new Side(0,0,1,3,3,3,0,0,13,this));
		SideList.Add (new Side(0,0,2,4,5,3,0,0,13,this));
	}
	
	void createSG() {
		this.cost = 2;
		SideList.Add (new Side(1,0,0,0,0,0,0,0,-1,this));
		SideList.Add (new Side(1,0,0,0,0,0,0,0,-1,this));
		SideList.Add (new Side(0,0,1,2,2,2,0,0,3,this));
		SideList.Add (new Side(0,0,1,2,2,2,0,0,3,this));
		SideList.Add (new Side(0,1,1,2,2,2,0,0,3,this));
		SideList.Add (new Side(0,1,1,2,2,2,0,0,3,this));
	}
	
	void createGS() {
		this.cost = 3;
		SideList.Add (new Side(1,0,0,0,0,0,0,0,-1,this));
		SideList.Add (new Side(1,0,0,0,0,0,0,0,-1,this));
		SideList.Add (new Side(2,0,0,0,0,0,0,0,-1,this));
		SideList.Add (new Side(0,0,1,2,2,2,0,0,14,this));
		SideList.Add (new Side(0,0,1,2,2,2,0,0,14,this));
		SideList.Add (new Side(0,0,2,3,3,2,0,0,14,this));
	}
	
	void createDHQ() {
		this.cost = 3;
		SideList.Add (new Side(1,0,0,0,0,0,0,0,-1,this));
		SideList.Add (new Side(2,0,0,0,0,0,0,0,-1,this));
		SideList.Add (new Side(0,0,1,0,3,2,0,0,-1,this));
		SideList.Add (new Side(0,0,1,0,3,2,0,0,-1,this));
		SideList.Add (new Side(0,0,2,2,4,2,0,0,-1,this));
		SideList.Add (new Side(0,1,2,2,4,2,0,0,4,this));
	}
	
	void createPO() {
		this.cost = 8;
		SideList.Add (new Side(1,0,0,0,0,0,0,0,-1,this));
		SideList.Add (new Side(2,0,0,0,0,0,0,0,-1,this));
		SideList.Add (new Side(2,0,0,0,0,0,0,0,-1,this));
		SideList.Add (new Side(0,0,2,0,0,2,0,0,15,this));
		SideList.Add (new Side(0,0,2,0,0,2,0,0,15,this));
		SideList.Add (new Side(0,0,2,0,0,2,0,0,15,this));
	}
	
	void createWQ() {
		this.cost = 4;
		SideList.Add (new Side(1,0,0,0,0,0,0,0,-1,this));
		SideList.Add (new Side(2,0,0,0,0,0,0,0,-1,this));
		SideList.Add (new Side(2,0,0,0,0,0,0,0,-1,this));
		SideList.Add (new Side(0,0,1,2,3,2,0,0,16,this));
		SideList.Add (new Side(0,0,1,2,3,2,0,0,16,this));
		SideList.Add (new Side(0,0,2,3,4,2,0,0,16,this));
	}
	
	void createQD() {
		this.cost = 8;
		SideList.Add (new Side(1,0,0,0,0,0,0,0,-1,this));
		SideList.Add (new Side(2,0,0,0,0,0,0,0,-1,this));
		SideList.Add (new Side(0,0,0,0,0,0,0,0,17,this));
		SideList.Add (new Side(0,0,1,4,4,4,0,0,5,this));
		SideList.Add (new Side(0,0,2,6,6,4,0,0,5,this));
		SideList.Add (new Side(0,0,3,8,7,4,0,0,5,this));
	}
	
	void createDD() {
		this.cost = 3;
		SideList.Add (new Side(1,0,0,0,0,0,0,0,-1,this));
		SideList.Add (new Side(2,0,0,0,0,0,0,0,-1,this));
		SideList.Add (new Side(2,0,0,0,0,0,0,0,-1,this));
		SideList.Add (new Side(0,0,1,3,2,2,0,0,18,this));
		SideList.Add (new Side(0,0,1,3,2,2,0,0,18,this));
		SideList.Add (new Side(0,0,1,3,2,2,0,0,18,this));
	}
	
	void createQW() {
		this.cost = 7;
		SideList.Add (new Side(0,0,0,0,0,0,0,0,6,this));
		SideList.Add (new Side(2,0,0,0,0,0,0,0,-1,this));
		SideList.Add (new Side(0,1,0,0,0,0,0,0,7,this));
		SideList.Add (new Side(0,0,1,2,5,3,0,0,-1,this));
		SideList.Add (new Side(0,0,2,3,6,3,0,0,-1,this));
		SideList.Add (new Side(0,2,3,4,8,3,0,0,8,this));
	}
	
	void createDP() {
		this.cost = 5;
		SideList.Add (new Side(1,0,0,0,0,0,0,0,-1,this));
		SideList.Add (new Side(2,0,0,0,0,0,0,0,-1,this));
		SideList.Add (new Side(2,0,0,0,0,0,0,0,-1,this));
		SideList.Add (new Side(0,1,1,1,5,2,0,0,9,this));
		SideList.Add (new Side(0,1,2,2,6,2,0,0,9,this));
		SideList.Add (new Side(0,2,3,2,8,2,0,0,9,this));
	}
	
	void createS() {
		this.cost = 4;
		SideList.Add (new Side(2,0,0,0,0,0,0,0,-1,this));
		SideList.Add (new Side(2,0,0,0,0,0,0,0,-1,this));
		SideList.Add (new Side(0,0,0,0,0,0,0,0,19,this));
		SideList.Add (new Side(0,0,0,0,0,0,3,4,-1,this));
		SideList.Add (new Side(0,0,0,0,0,0,3,4,-1,this));
		SideList.Add (new Side(0,0,0,0,0,0,3,4,-1,this));
	}
	
	void createG() {
		this.cost = 5;
		SideList.Add (new Side(1,0,0,0,0,0,0,0,-1,this));
		SideList.Add (new Side(2,0,0,0,0,0,0,0,-1,this));
		SideList.Add (new Side(2,0,0,0,0,0,0,0,-1,this));
		SideList.Add (new Side(0,0,0,0,0,0,1,5,-1,this));
		SideList.Add (new Side(0,0,0,0,0,0,1,5,-1,this));
		SideList.Add (new Side(0,0,0,0,0,0,1,5,-1,this));
	}
	
	void createD() {
		this.cost = 5;
		SideList.Add (new Side(1,0,0,0,0,0,0,0,-1,this));
		SideList.Add (new Side(2,0,0,0,0,0,0,0,-1,this));
		SideList.Add (new Side(2,0,0,0,0,0,0,0,-1,this));
		SideList.Add (new Side(0,1,0,0,0,0,4,5,11,this));
		SideList.Add (new Side(0,1,0,0,0,0,4,5,11,this));
		SideList.Add (new Side(0,2,0,0,0,0,4,5,12,this));
	}
	
	void createV() {
		this.cost = 9;
		SideList.Add (new Side(1,0,0,0,0,0,0,0,-1,this));
		SideList.Add (new Side(2,0,0,0,0,0,0,0,-1,this));
		SideList.Add (new Side(2,0,0,0,0,0,0,0,-1,this));
		SideList.Add (new Side(0,0,0,0,0,0,0,0,20,this));
		SideList.Add (new Side(0,0,0,0,0,0,4,9,0,this));
		SideList.Add (new Side(0,0,0,0,0,0,4,9,0,this));
	}
	
	void createL() {
		this.cost = 4;
		SideList.Add (new Side(1,0,0,0,0,0,0,0,-1,this));
		SideList.Add (new Side(2,0,0,0,0,0,0,0,-1,this));
		SideList.Add (new Side(2,0,0,0,0,0,0,0,-1,this));
		SideList.Add (new Side(0,0,0,0,0,0,2,4,-1,this));
		SideList.Add (new Side(0,0,0,0,0,0,2,4,-1,this));
		SideList.Add (new Side(0,0,0,0,0,0,2,4,-1,this));
	}
	//determines if Die's active side is a spell
	public bool IsActiveSpell(){
		for(int i=0; i<spelltags.Length; i++){
			if(this.tag == spelltags[i]){
				if(this.ActiveSide.spelltype != 0){
					return true;
				}
			}
		}
		return false;
	}
	public bool IsCreature(){
		for(int i=0; i<SideList.Count; i++){
			if(SideList[i].glory > 0){
				return true;
			}
		}
		return false;
	}
	public bool IsActiveCreature(){
		if(this.ActiveSide.glory != 0)
			return true;
		else
			return false;
	}
	
	public float averageQuid(){
		float ret = 0;
		for(int i=0; i<SideList.Count; i++){
			ret += (float)SideList[i].quiddity;
		}
		return ret/6f;
	}
	
	public float averageAttack(){
		float ret = 0;
		for(int i=0; i<SideList.Count; i++){
			ret += (float)SideList[i].power;
		}
		return ret/6f;
	}
	
	public float averageDefense(){
		float ret = 0;
		for(int i=0; i<SideList.Count; i++){
			ret += (float)SideList[i].toughness;
		}
		return ret/6f;
	}
	
	public float averageGlory(){
		float ret = 0;
		for(int i=0; i<SideList.Count; i++){
			ret += (float)SideList[i].glory;
		}
		return ret/6f;
	}
	
	public float NumCreatureSides(){
		float ret = 0;
		for(int i=0; i<SideList.Count; i++){
			if(SideList[i].glory > 0){
				ret++;
			}
		}
		return ret;
	}
	
	public float ProbRollDefLessThan(float avgatt){
		float sides = 0;
		for(int i=0; i<SideList.Count; i++){
			if(SideList[i].toughness < avgatt){
				sides++;
			}
		}
		return sides/6f;
	}
	
	public float ProbRollAttackGreaterThan(int def){
		float sides = 0;
		for(int i=0; i<SideList.Count; i++){
			if(SideList[i].power > def){
				sides++;
			}
		}
		return sides/6f;
	}
}
