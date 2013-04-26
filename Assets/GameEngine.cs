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
		//Scoring Phase
		//update player gamestate with creature score
		//move all creature & spell die from ready to used
		//(Optional) choose to cull die
		//(Optional) Handle creature on score abilities
		yield return StartCoroutine(ScorePhase());
		
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
		//move all creature & spell die to used pile
		yield return CullDie();
		yield return HandleOnScore();
	}
	
	IEnumerator CullDie(){
		//wait for player to choose if they want to cull a die
		yield return null;
	}
	
	IEnumerator HandleOnScore(){
		//wait for player to determine if they want on score events
		yield return null;
	}
	
	IEnumerator DrawAndRoll(){
		//if 6 or more dice - draw and roll
		//move to active
		//resolve immediate effects
		yield return ResolveImmediate();
		
		//else - draw and roll
		//move to active 
		//resolve immediate effects
		//refill bag from used
		yield return ResolveImmediate();
		
		//draw and roll again
	}
	
	IEnumerator ResolveImmediate(){
		//prompt player for input on how to resolve immediate
		yield return null;
	}
		
	IEnumerator ReadyAndSummon(){
		//move spells to ready area
		//summon creatures
		yield return SummonCreature();
		//move spent dice to used pile
	}
	
	IEnumerator SummonCreature(){
		//prompt player to summon particular creatures
		yield return null;
	}
	
	IEnumerator Attack(){
		while(battle){
			//total attack number
			//opponent selects defend order
			yield return PickComputerDefender();
			//subtract defense from attack
			//handle on death events
			yield return HandleOnDeath();
			//if no more creatures or attack -- phase over
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
		//total quiddity in active pool & effects, creatures & spells
		while(numBuys > 0){
			//purchase die
			yield return PurchaseDie();
			//decrement num buys & active total quid
		}
		//move dice from active pool to used pile
		//move spells from ready to used
		yield return MoveSpells ();
	}
	
	IEnumerator PurchaseDie(){
		//prompt player to purchase die
		yield return null;
	}
	
	IEnumerator MoveSpells(){
		//determine if player wants to move spells
		yield return null;
	}
	
	IEnumerator ComputerTurn(){
	}
	
}
