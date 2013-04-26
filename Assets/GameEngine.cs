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
		
		//testing
		foreach(Card card in GameState.Cards){
			Debug.Log(card.ToString());
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
