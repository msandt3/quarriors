using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	public DiceBag diceBag;
	public ReadyArea readyArea;
	public ActiveArea activeArea;
	public UsedArea usedArea;
	public SpentArea spentArea;
	public int currentGlory;

	// Use this for initialization
	void Start () {
		diceBag = new DiceBag();
		readyArea = new ReadyArea();
		activeArea = new ActiveArea();
		usedArea = new UsedArea();
		spentArea = new SpentArea();
		currentGlory = 0;
		
		//initialize diceBag with starting dice
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public Dice DrawFromBag(int num){
		//add check to see if there are no dice in bag, if none add used pool to bag and continue
		int randomVal = (int)(Random.value*diceBag.diceList.Count);
		Dice chosenDice = (Dice)(diceBag.diceList[randomVal]);
		diceBag.diceList.RemoveAt(randomVal);
		activeArea.diceList.Add(chosenDice);
		return chosenDice;
		
		
		
		
	}
	
	public void MoveUsedToBag(){
		ArrayList usedAreaCopy =(ArrayList) usedArea.diceList.Clone();
		diceBag.diceList.AddRange(usedAreaCopy);
		usedArea = new UsedArea();
		
		
	}
	
	public void MoveFromActiveToSpent(Dice d){
		activeArea.diceList.Remove(d);
		spentArea.diceList.Add(d);

	}
}
