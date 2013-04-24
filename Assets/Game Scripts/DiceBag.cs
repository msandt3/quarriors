using UnityEngine;
using System.Collections;

public class DiceBag {
	public ArrayList diceList;
	public int numOfDiceInBag;
	
	
	// Use this for initialization
	public DiceBag(){
		diceList = new ArrayList();
	}
	
	
	public void updateNumOfDice(){
		numOfDiceInBag = diceList.Count;
	}
}
