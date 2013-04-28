using UnityEngine;
using System.Collections;

public class GameEngine : MonoBehaviour {
	//Decks and areas
	public GameObject ZoomArea;
	public GameObject BasicDeck;
	public GameObject SpellDeck;
	public GameObject CreatureDeck;
	public GameObject CardArea;
	
	public CardAreaController CardController { get; set;}
	public Game GameState { get; set;}
	
	// Use this for initialization
	void Start () {
		//set up the gamestate
		GameState = new Game();
		//set up the card controller
		CardController = CardArea.AddComponent<CardAreaController>();
		CardController.ZoomArea = this.ZoomArea;
		CardController.BasicDeck = this.BasicDeck;
		CardController.SpellDeck = this.SpellDeck;
		CardController.CreatureDeck = this.CreatureDeck;
		CardController.CardArea = this.CardArea;
		CardController.SetUpDecks();
		
		//set the game's card references 
		GameState.Cards = CardController.GetCards();
		
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	IEnumerator UpdateGameState(){
		//while game is still being played
		while(!GameState.isWin()){
			//player 1's turn
			yield return Player1Turn();
			//computer's turn
		}
	}
	
	IEnumerator Player1Turn(){
		
		//reset p1's quiddity count
		GameState.p1.ActiveQuid = 0;
		
		//Scoring Phase
		//update player gamestate with creature score
		//move all creature & spell die from ready to used
		//(Optional) choose to cull die
		//(Optional) Handle creature on score abilities
		yield return ScorePhase();
		
		//Draw & Roll Phase
		//shuffle & roll dice
		//move to active pool
		//resolve immediate effects
		//no dice left - refill bag from used pile
		yield return DrawAndRoll();
		
		//Ready Spells & Summon Creatures
		//Move spells to ready area
		//Summon creatures - move to ready area
		//move spent dice to used pile
		yield return ReadyAndSummon();
		
		//Attack Rivals
		//total damage & attack -- include spells
		//wait for opponent to pick defending order
		//opponents defense from attack
		//handle on death events
		//repeat
		yield return Attack();
		
		//(Optional) Capture one die from wilds
		//Total quiddity in active pool & effects, creatures, spells
		//Purchase die
		//Move dice from active pool to used pile
		//(Optional) move spells from ready area to used pile
		yield return HandleCaptureDie();
		
	}
	
	IEnumerator ScorePhase(){
		//update gamestate with glory gained
		GameState.p1.ScoreCreatures(); //need to do something about player gaining enough glory after scoring
		
		//move all creature & spell die to used pile
		GameState.p1.AllActiveToUsed();
		
		yield return CullDie();
		yield return HandleOnScore();
	}
	
	IEnumerator CullDie(){
		//wait for player to choose if they want to cull a die
		Die d = null;
		//get the die from the used pile
		GameState.p1.CullDie(d);
		GameState.CullDie(d);
		yield return null;
	}
	
	IEnumerator HandleOnScore(){
		//wait for player to determine if they want on score events
		yield return null;
	}
	
	IEnumerator DrawAndRoll(){
		//if 6 or more dice - draw and roll
		//move to active
		GameState.p1.DrawAndRoll();
		//resolve immediate effects
		yield return ResolveImmediate();
	}
	
	IEnumerator ResolveImmediate(){
		//prompt player for input on how to resolve immediate
		yield return null;
	}
		
	IEnumerator ReadyAndSummon(){
		//move spells to ready area
		GameState.p1.SpellstoReady();
		//update players quiddity
		GameState.p1.UpdateQuiddity();
		//summon creatures
		yield return SummonCreature();
		//move spent dice to used pile
		GameState.p1.SpentToUsed();
	}
	
	IEnumerator SummonCreature(){
		//prompt player to summon particular creatures
		
		//create a string of the creature you want to summon
		yield return null;
	}
	
	IEnumerator Attack(){
		bool battle = true;
		while(battle){
			//total attack number
			int TotAtt = GameState.p1.TotalAttack();
			//opponent selects defend order
			yield return PickComputerDefender();
			//subtract defense from attack
			//handle on death events
			yield return HandleOnDeath();
			//if no more creatures or attack -- phase over
			if(TotAtt == 0 || GameState.p2.NumCreaturesReady() == 0){
				battle = false;
			}
		}
	}
	
	IEnumerator PickComputerDefender(){
		//prompt opponent for defend order
		yield return null;
	}
	
	IEnumerator HandleOnDeath(){
		//prompt opponent to handle on death events
		yield return null;
	}
	
	IEnumerator HandleCaptureDie(){
		//determine num buys allowed
		int numBuys = 1;
		//total quiddity in active pool & effects, creatures & spells
		GameState.p1.UpdateQuiddity();
		while(numBuys > 0 && GameState.p1.ActiveQuid > 0){
			//purchase die -- the GUI should return a string corresponding to the bough die name
			yield return PurchaseDie();
			
			//decrement num buys & active total quid
			numBuys--;
			
		}
		//move dice from active pool to used pile
		GameState.p1.AllActiveToUsed();
		//move spells from ready to used
		yield return MoveSpells ();
	}
	
	IEnumerator PurchaseDie(){
		//prompt player to purchase die
		Die newDie = GameState.BuyDie("BQ");
		GameState.p1.AddBoughtDie(newDie);
		GameState.p1.UpdateQuiddity();
		yield return null;
	}
	
	IEnumerator MoveSpells(){
		//determine if player wants to move spells
		yield return null;
	}
	
	IEnumerator ComputerTurn(){
	}
	
}
