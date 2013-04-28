using UnityEngine;
using System.Collections;

public class GameEngine : MonoBehaviour {
	//Decks and areas
	public GameObject ZoomArea;
	public GameObject BasicDeck;
	public GameObject SpellDeck;
	public GameObject CreatureDeck;
	public GameObject CardArea;
	private bool culling;
	
	public CardAreaController CardController { get; set;}
	public Game GameState { get; set;}
	public GUIChoiceWindows gcw;
	public int state;
	public int numCreaturesScored = 0;
	// Use this for initialization
	void Start () {
		culling = false;
		//set up the gamestate
		GameState = new Game();
		//GameState.p1.UsedPile.Add (new Die("BQ"));
		gcw = this.transform.GetComponent<GUIChoiceWindows>();
		//set up the card controller
		CardController = CardArea.AddComponent<CardAreaController>();
		CardController.ZoomArea = this.ZoomArea;
		CardController.BasicDeck = this.BasicDeck;
		CardController.SpellDeck = this.SpellDeck;
		CardController.CreatureDeck = this.CreatureDeck;
		CardController.CardArea = this.CardArea;
		CardController.SetUpDecks();
		state = 0;
		//set the game's card references 
		GameState.Cards = CardController.GetCards();
		//StartCoroutine(UpdateGameState ());
		
		
	}
	
	// Update is called once per frame
	void Update () {
		Die dice;
		if (!GameState.isWin ()) {
			switch(state) {
			case 0:
				// Scores creatures and pops up the CullCheck window.
				numCreaturesScored = 0;
				Debug.Log("State 0");
				numCreaturesScored = ScoreCreatures (GameState.p1);
				gcw.showCullCheck ();
				state = 1;
				break;
			case 1:
				// Handles the CullCheck window.
				bool choice = gcw.getCullChoice();
				if (gcw.hasChosen) {
					Debug.Log ("We've chosen");
					if (choice) {
						state = 2;
					}
					else
						state = 4;
				}
				Debug.Log ("State 1");
				break;
			case 2:
				// Shows the Cull window.
				gcw.showCullWindow (GameState.p1.UsedPile);
				state = 3;
				Debug.Log ("state 2");
				break;
			case 3:
				// Handles the Cull window.
				Debug.Log ("state 3");
				Die d = gcw.showCullWindow (GameState.p1.UsedPile);
				if (gcw.hasChosen) {
					if (d == null) {
						state = 4;
					}
					else {
						GameState.p1.CullDie (d);
						GameState.CullDie (d);
						numCreaturesScored--;
						if (numCreaturesScored > 0) {
							state = 2;
						}
						else {
							state = 4;
						}
					}
				}
				break;
			case 4:
				Debug.Log("State 4");
				state = 0;
				break;
			case 5:
				break;
			case 6:
				break;
			}
		}
	}
	
//	void runGame() {
//		int numCreaturesScored = 0;
//		while(!GameState.isWin()) {
//			
//		}
//	}
	
	public int ScoreCreatures(Player play) {
		return 0;
	}
	
	void cull(Player play, int numDie) {
		
	}
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
//	IEnumerator UpdateGameState(){
//		//while game is still being played
//		//Debug.Log("Starting game loop");
//		while(!GameState.isWin()){
//			//Debug.Log ("In Loop");
//			//player 1's turn
//			yield return StartCoroutine(Player1Turn());
//			//computer's turn
//		}
//	}
//	
//	IEnumerator Player1Turn(){
//		//Debug.Log("Player 1's Turn");
//		//reset p1's quiddity count
//		GameState.p1.ActiveQuid = 0;
//		
//		//Scoring Phase
//		//update player gamestate with creature score
//		//move all creature & spell die from ready to used
//		//(Optional) choose to cull die
//		//(Optional) Handle creature on score abilities
//		yield return StartCoroutine(ScorePhase());
//		Debug.Log("Scored");
//		//Draw & Roll Phase
//		//shuffle & roll dice
//		//move to active pool
//		//resolve immediate effects
//		//no dice left - refill bag from used pile
//		yield return StartCoroutine(DrawAndRoll());
//		Debug.Log("Draw & Roll");
//		//Ready Spells & Summon Creatures
//		//Move spells to ready area
//		//Summon creatures - move to ready area
//		//move spent dice to used pile
//		//yield return ReadyAndSummon();
//		//Debug.Log("Readied & Summoned");
//		//Attack Rivals
//		//total damage & attack -- include spells
//		//wait for opponent to pick defending order
//		//opponents defense from attack
//		//handle on death events
//		//repeat
//		//yield return Attack();
//		//Debug.Log("Attack");
//		//(Optional) Capture one die from wilds
//		//Total quiddity in active pool & effects, creatures, spells
//		//Purchase die
//		//Move dice from active pool to used pile
//		//(Optional) move spells from ready area to used pile
//		//yield return HandleCaptureDie();
//		//Debug.Log("Capture");
//		
//		//yield return StartCoroutine(ScorePhase());
//		//Debug.Log("Scoring 2");
//		
//	}
//	
//	IEnumerator ScorePhase(){
//		//update gamestate with glory gained
//		GameState.p1.ScoreCreatures(); //need to do something about player gaining enough glory after scoring
//		//Debug.Log ("Creatures Scored");
//		//move all creature & spell die to used pile
//		GameState.p1.AllActiveToUsed();
//		//Debug.Log("Active to used");
//		
//		yield return StartCoroutine(CullDie());
//		Debug.Log ("Die Culled");
//		//yield return HandleOnScore();
//		yield return null;
//	}
//	
//	IEnumerator CullDie(){
//		//wait for player to choose if they want to cull a die
//		gcw.showCullCheck();
//		Debug.Log("Chosen - " + gcw.hasChosen);
//		Debug.Log("Cull Check - " + gcw.isCullCheckWindow);
//		//Debug.Log ("Checking for culled die");
//		//while gui hasnt returned something
//			//wait
//		int i =0;
//		while (true) {
//			//Debug.Log ("IN CHECK LOOP");
//			bool choice = gcw.getCullChoice();
//			Debug.Log("Cull Check - " + gcw.isCullCheckWindow);
//			if (gcw.hasChosen) {
//				if(choice) {
//					yield return StartCoroutine (CullDieChoice ());
//					break;
//				}
//				else {
//					break;
//				}
//			}
//			i++;
//			yield return null;
//		}
////		Die d = null; // set die to gui return val
////		//get the die from the used pile
////		GameState.p1.CullDie(d);
////		GameState.CullDie(d);
//		yield return null;
//	}
//	
//	IEnumerator CullDieChoice() {
//		//culling = true;
//		//Debug.Log ("Culling");
//		//gcw.choiceNumber = gcw.WAITING;
//		while(true) {
//			Die dice = gcw.showCullWindow (GameState.p1.UsedPile);
//			if (gcw.hasChosen) {
//				if(dice != null){
//					GameState.p1.CullDie(dice);
//					GameState.CullDie(dice);
//					break;
//				}
//				else
//					break;
//			}
//			yield return null;
//		}
//		yield return null;
//	}
//	
//	IEnumerator HandleOnScore(){
//		//wait for player to determine if they want on score events
//		yield return null;
//	}
//	
//	IEnumerator DrawAndRoll(){
//		//if 6 or more dice - draw and roll
//		//move to active
//		Debug.Log ("P1 BAG " + GameState.p1.Bag.Count);
//		GameState.p1.DrawAndRoll();
//		Debug.Log ("P1 BAG AFTER DRAW " + GameState.p1.Bag.Count);
//		Debug.Log ("P1 ACTIVE POOL " + GameState.p1.ActivePool.Count);
//		Debug.Log ("Drawing");
//		while(true) {
//			Die dice = gcw.showResolveWindow (GameState.p1.ActivePool);
//			if (gcw.hasChosen) {
//				if(dice == null) {
//					break;
//				}
//				else
//					break;
//			}
//			yield return null;
//		}
//		//resolve immediate effects
//		yield return null;
//		//yield return ResolveImmediate();
//	}
//	
//	IEnumerator ResolveImmediate(){
//		//prompt player for input on how to resolve immediate
//		yield return null;
//	}
//		
//	IEnumerator ReadyAndSummon(){
//		//move spells to ready area
//		GameState.p1.SpellstoReady();
//		//update players quiddity
//		GameState.p1.UpdateQuiddity();
//		//summon creatures
//		yield return SummonCreature();
//		//move spent dice to used pile
//		GameState.p1.SpentToUsed();
//	}
//	
//	IEnumerator SummonCreature(){
//		//prompt player to summon particular creatures
//		yield return null;
//	}
//	
//	IEnumerator Attack(){
//		bool battle = true;
//		while(battle){
//			//total attack number
//			int TotAtt = GameState.p1.TotalAttack();
//			//opponent selects defend order
//			yield return PickComputerDefender();
//			//subtract defense from attack
//			//handle on death events
//			yield return HandleOnDeath();
//			//if no more creatures or attack -- phase over
//			if(TotAtt == 0 || GameState.p2.NumCreaturesReady() == 0){
//				battle = false;
//			}
//		}
//	}
//	
//	IEnumerator PickComputerDefender(){
//		//prompt opponent for defend order
//		yield return null;
//	}
//	
//	IEnumerator HandleOnDeath(){
//		//prompt opponent to handle on death events
//		yield return null;
//	}
//	
//	IEnumerator HandleCaptureDie(){
//		//determine num buys allowed
//		int numBuys = 1;
//		//total quiddity in active pool & effects, creatures & spells
//		GameState.p1.UpdateQuiddity();
//		while(numBuys > 0 && GameState.p1.ActiveQuid > 0){
//			//purchase die -- the GUI should return a string corresponding to the bough die name
//			yield return PurchaseDie();
//			
//			//decrement num buys & active total quid
//			numBuys--;
//			
//		}
//		//move dice from active pool to used pile
//		GameState.p1.AllActiveToUsed();
//		//move spells from ready to used
//		yield return MoveSpells ();
//	}
//	
//	IEnumerator PurchaseDie(){
//		//prompt player to purchase die
//		Die newDie = GameState.BuyDie("BQ");
//		GameState.p1.AddBoughtDie(newDie);
//		GameState.p1.UpdateQuiddity();
//		yield return null;
//	}
//	
//	IEnumerator MoveSpells(){
//		//determine if player wants to move spells
//		yield return null;
//	}
//	
//	IEnumerator ComputerTurn(){
//		return null;
//	}
	
}
