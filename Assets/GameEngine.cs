using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameEngine : MonoBehaviour {
	//Decks and areas
	public GameObject ZoomArea;
	public GameObject BasicDeck;
	public GameObject SpellDeck;
	public GameObject CreatureDeck;
	public GameObject CardArea;
	private bool culling;
	public QuarriorAgent qa;
	public List<Die> purchased;
	public List<Die> summoned;
	public List<Die> dO;
	
	public CardAreaController CardController { get; set;}
	public Game GameState { get; set;}
	public GUIChoiceWindows gcw;
	public int state;
	public int totalPower;
	public Die resolving;
	public int totalDefense;
	public int numCreaturesScored = 0;
	// Use this for initialization
	void Start () {
		culling = false;
		//set up the gamestate
		GameState = new Game();
		qa = new QuarriorAgent(GameState,GameState.p1,GameState.p2);
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
				GameState.turn++;
				//GameState.p1.AllActiveToUsed ();
				// Scores creatures and pops up the CullCheck window.
				GameState.p1.ActiveQuid = 0;
				GameState.p2.ActiveQuid = 0;
				totalPower = 0;
				totalDefense = 0;
				numCreaturesScored = 0;
				//Debug.Log("State 0");
				numCreaturesScored = ScoreCreatures (GameState.p1);
				Debug.Log ("Scoring: " + numCreaturesScored);
				Debug.Log("Glory: " + GameState.p1.Glory);
				gcw.showCullCheck ();
				state = 1;
				break;
			case 1:
				// Handles the CullCheck window.
				bool choice = gcw.getCullChoice();
				if (gcw.hasChosen) {
					//Debug.Log ("We've chosen");
					if (choice) {
						state = 2;
					}
					else
						state = 1000;
				}
				//Debug.Log ("State 1");
				break;
			case 2:
				// Shows the Cull window.
				gcw.showCullWindow (GameState.p1.UsedPile);
				state = 3;
				//Debug.Log ("state 2");
				break;
			case 3:
				// Handles the Cull window.
				//Debug.Log ("state 3");
				Die d = gcw.showCullWindow (GameState.p1.UsedPile);
				if (gcw.hasChosen) {
					if (d == null) {
						state = 1000;
					}
					else {
						if (numCreaturesScored > 0) {
							GameState.p1.CullDie (d);
							GameState.CullDie (d);
							numCreaturesScored--;
							state = 2;
						}
						else {
							state = 1000;
						}
					}
				}
				break;
			case 1000:
				gcw.isCullWindow = false;
				//CardController.UpdateWilds ();
				//Debug.Log("State 4");
				GameState.p1.DrawAndRoll();
				state = 4;
				break;
			case 4:
				//Debug.Log ("COMING INTO STATE $");
				// Draw and Roll
				gcw.showResolveWindow (GameState.p1.ActivePool);
				state = 5;
				break;
			case 5:
				// Activate Immediate Effects
				//Debug.Log ("State 5");
				Die d1 = gcw.showResolveWindow (GameState.p1.ActivePool);
				if (gcw.hasChosen) {
					if (d1 == null) {
						state = 6;
					}
					else {
						if (d1.ActiveSide.quiddity == 0 && d1.ActiveSide.glory == 0) {
							resolveDie (d1, GameState.p1);
						}
					}
				}
				break;
			case 6:
				// Ready Spells and Summon Creatures
				//Debug.Log ("state 6");
				RemoveSpells ();
				GameState.p1.UpdateQuiddity();
				state = 7;
				break;			
			case 7:
				// Shows creature window
				//Debug.Log ("state 7");
				gcw.showCreatureWindow(GameState.p1.ActivePool);
				Debug.Log ("Active QUiddity: " + GameState.p1.ActiveQuid);
				state = 8;
				break;
			case 8:
				// Handles Creature window
				//Debug.Log ("state 8");
				Die d2 = gcw.showCreatureWindow (GameState.p1.ActivePool);
				if (gcw.hasChosen) {
					if (d2 == null) {
						state = 9;
					}
					else {
						Debug.Log ("Before purchase: " + GameState.p1.ActiveQuid);
						if (d2.ActiveSide.glory > 0) {
							//Debug.Log("in");
							Debug.Log("Creature Cost: " + d2.ActiveSide.creatureCost);
							if (d2.ActiveSide.creatureCost <= GameState.p1.ActiveQuid) {
								GameState.p1.ActiveQuid -= d2.ActiveSide.creatureCost;
								GameState.p1.ActivePool.Remove (d2);
								GameState.p1.ReadyArea.Add (d2);
								Debug.Log ("After purchase: " + GameState.p1.ActiveQuid);
								state = 7;
							}
						}
					}
				}
				break;
			case 9:
				totalPower = 0;
				totalDefense = 0;
				// Displays attack window
				//Debug.Log ("state 9");
				for (int i = 0; i < GameState.p1.ReadyArea.Count; i++) {
					if (GameState.p1.ReadyArea[i].ActiveSide.power > 0) {
						totalPower += GameState.p1.ReadyArea[i].ActiveSide.power;
					}
				}
				gcw.showAttackWindow (GameState.p1.ReadyArea);
				state = 10;
				break;
			case 10:
				//Debug.Log ("state 10");
				Die d3 = gcw.showAttackWindow (GameState.p1.ReadyArea);
				if(gcw.hasChosen) {
					if (d3 == null) {
						state = 11;
					}
					else {
						state = 10;
					}
				}
				break;
			case 11:
				dO = new List<Die>();
				//int woo = 0;
				dO = qa.DefendOrder (totalPower,GameState.p2);
				//Debug.Log ("state 11");
				// Displays defense window
				for (int i = 0; i < GameState.p2.ReadyArea.Count; i++) {
					if (GameState.p2.ReadyArea[i].ActiveSide.toughness > 0) {
						totalDefense += GameState.p2.ReadyArea[i].ActiveSide.toughness;
					}
				}
				//Debug.Log ("Break now?");
				if(GameState.p2.ReadyArea.Count != 0) {
					Debug.Log ("in");
					gcw.showCPUDefenseWindow(dO);
				}
				else {
					gcw.showCPUDefenseWindow(GameState.p2.ReadyArea);
				}
				if (totalPower >= totalDefense) {
					GameState.p2.UsedPile.AddRange (GameState.p2.ReadyArea);
					if (dO != null) {
						dO.Clear ();
					}
					//dO.Clear ();
					GameState.p2.ReadyArea.Clear();
				}
				else {
					while(totalPower > 0) {
						if(totalPower >= dO[0].ActiveSide.toughness) {
							GameState.p2.ReadyArea.Remove (dO[0]);
							GameState.p2.UsedPile.Add(dO[0]);
							totalPower -= dO[0].ActiveSide.toughness;
							totalDefense -= dO[0].ActiveSide.toughness;
							dO.RemoveAt (0);
						}
						else {
							totalPower = 0;
						}
					}
				}
				state = 12;
				break;
			case 12:
				// Need to fix CPU defense
				Die d4;
				//Handles defense window
				//Debug.Log ("state 12");
				if (GameState.p2.ReadyArea.Count != 0) {
					Debug.Log ("in");
					d4 = gcw.showCPUDefenseWindow (dO);
				}
				else {
					d4 = gcw.showCPUDefenseWindow (GameState.p2.ReadyArea);
				}
				if(gcw.hasChosen) {
					if (d4 == null) {
						state = 13;
					}
					else {
						state = 12;
					}
				}
				break;
			case 13:
				// *FIXED*
				//Debug.Log ("state 13");
				gcw.showBuyWindow (this.CardController.dice);
				state = 14;
				break;
			case 14:
				// Handles to die window
				//Debug.Log ("state 14");
				Die d5 = gcw.showBuyWindow (this.CardController.dice);
				if(gcw.hasChosen) {
					if(d5 == null) {
						state = 15;
					}
					else {
						if (d5.cost <= GameState.p1.ActiveQuid) {
							GameState.p1.ActiveQuid -= d5.cost;
							GameState.BuyDie (d5);
							GameState.p1.UsedPile.Add (d5);
							this.CardController.UpdateWilds ();
							// Remove goes here
							state = 15;
						}
						else {
							Debug.Log ("You do not have enough quiddity");
							state = 13;
						}
					}
				}
				break;
			case 15:
				// Moves all active die to used pile
				//Debug.Log ("state 15");
				GameState.p1.AllActiveToUsed ();
				state = 16;
				break;
			case 16:
				//Shows window for CPU turn and handles it
				//Debug.Log ("state 16");
				numCreaturesScored = 0;
				numCreaturesScored = ScoreCreatures (GameState.p2);
				Debug.Log ("Creatuers scored: " + numCreaturesScored);
				Debug.Log (GameState.p2.Glory);
				state = 1600;
				break;
			case 1600:
				gcw.showOKWindow("CPU's turn...", "");
				if(gcw.hasChosen) {
					state = 17;
				}
				else {
					state = 1600;
				}
				break;
			case 17:
				// Shows die CPU culled
				// Call dice cull method
				Debug.Log ("Running cull agent sequence");
				gcw.showDiceViewWindow(qa.CullAction(numCreaturesScored,GameState.turn),"These are the die the CPU culled...");
				//gcw.showOKWindow ("These are the die the CPU culled...", "");
				if (gcw.hasChosen) {
					state = 18;
				}
				break;
			case 18:
				Debug.Log("state 18");
				GameState.p2.DrawAndRoll ();
				GameState.p2.UpdateQuiddity ();
				state = 19;
				break;
			case 19:
				gcw.showDiceViewWithTextWindow (GameState.p2.ActivePool,"These are the die the CPU rolled...", "");
				if (gcw.hasChosen) {
					state = 20;
				}
				// Handles window
				break;
			case 20:
				// Add resolve die choice
				summoned = qa.SummonAction(GameState.turn,CardController.dice);
				state = 2000;
				//
				break;
			case 2000:
				gcw.showDiceViewWithTextWindow (summoned,"CPU is resolving this die...", "");
				//totalPower = 0;
				//totalDefense = 0;
				if (gcw.hasChosen) {
					state = 21;
				}
				break;
			case 21:
				totalPower = 0;
				gcw.showDiceViewWithTextWindow (GameState.p2.ReadyArea,"CPU is attacking with these creatures...", "");
				for (int i = 0; i < GameState.p2.ReadyArea.Count; i++) {
					totalPower += GameState.p2.ReadyArea[i].ActiveSide.power;
				}
				Debug.Log ("Total Power: " + totalPower);
				if (gcw.hasChosen) {
					state = 22;
				}
				break;
			case 22:
				totalDefense = 0;
				for (int i = 0; i < GameState.p1.ReadyArea.Count; i++) {
					totalDefense += GameState.p1.ReadyArea[i].ActiveSide.toughness;
				}
				Debug.Log ("Total Defense: " + totalDefense);
				gcw.showDefenseWindow (GameState.p1.ReadyArea);
				state = 23;
				break;
			case 23:
				Die d6 = gcw.showDefenseWindow (GameState.p1.ReadyArea);
				if(gcw.hasChosen) {
					if(d6 == null) {
						if (totalDefense == 0 || totalPower == 0) {
							state = 24;
						}
						else {
							state = 22;
						}
					}
					else {
						if (totalDefense == 0 || totalPower == 0) {
							state = 24;
						}
						else if (d6.ActiveSide.toughness > totalPower) {
							totalPower = 0;
							state = 24;
						}
						else {
							totalPower -= d6.ActiveSide.toughness;
							totalDefense -= d6.ActiveSide.toughness;
							GameState.p1.ReadyArea.Remove (d6);
							GameState.p1.UsedPile.Add (d6);
							state = 22;
						}
					}
				}
				else {
				}
				break;
			case 24:
				// Fix this to show die bought and move it into bag.
				purchased = new List<Die>();
				Die d24 = qa.BuyAction(CardController.dice);
				if(d24 != null) {
					purchased.Add (d24);
					CardController.UpdateWilds();
				}
				state = 2400;
				break;
			case 2400:
				gcw.showDiceViewWindow (purchased,"CPU is buying this die...");
				if (gcw.hasChosen) {
					state = 25;
				}
				break;
			case 25:
				GameState.p2.AllActiveToUsed ();
				gcw.showOKWindow ("CPU's turn is over...", "");
				if(gcw.hasChosen) {
					state = 26;
				}
				break;
			case 26:
				state = 0;
				break;
			case 27:
				break;
			case 28:
				break;
			case 29:
				// Assistant State
				gcw.showResolveWindow (GameState.p1.ActivePool);
				state = 30;
				break;
			case 30:
				Debug.Log("State 30");
				Die d30 = gcw.showResolveWindow (GameState.p1.ActivePool);
				if(gcw.hasChosen) {
					if (d30 == null){
						resolving.roll ();
						GameState.p1.ActivePool.Add (resolving);
						state = 4;
					}
					else {
						d30.roll ();
						resolving.roll ();
						GameState.p1.ActivePool.Add (resolving);
						state = 4;
					}
				}
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
	public void RemoveSpells(){
		//move them from active to ready
		foreach(Die d in GameState.p1.ActivePool){
			//if dies active side is a spell && not immediate
			if(d.ActiveSide.spelltype != 1 && d.ActiveSide.spelltype != 0){
				GameState.p1.ActivePool.Remove(d);
				GameState.p1.ReadyArea.Add(d);
			}
		}
	}
	public int ScoreCreatures(Player play) {
		int i = 0;
		for (int j = 0; j < play.ReadyArea.Count; j++) {
			if (play.ReadyArea[j].ActiveSide.glory > 0) {
				play.Glory += play.ReadyArea[j].ActiveSide.glory;
				i++;
			}
		}
		play.UsedPile.AddRange (play.ReadyArea);
		play.ReadyArea.Clear ();
//		foreach(Die d in play.ReadyArea) {
//			if (d.ActiveSide.glory > 0) {
//				play.Glory += d.ActiveSide.glory;
//				i++;
//				play.ReadyArea.Remove (d);
//				play.UsedPile.Add (d);
//			}
//		}
		return i;
	}
	
	void resolveDie(Die d, Player p) {
		int ID;
		Debug.Log("resolving");
		if (d.tag == "P") {
			ID = d.ActiveSide.specialID;
			if (ID == 1) {
				p.BagtoActive (1);
			}
			else if (ID == 2) {
				p.BagtoActive (2);
			}
			p.ActivePool.Remove (d);
			p.UsedPile.Add (d);
		}
		else if (d.tag == "A") {
			Debug.Log ("going into A");
			ID = d.ActiveSide.specialID;
			if (ID == 0) {
				p.ActivePool.Remove (d);
				resolving = d;
				d.roll ();
				state = 29;
			}
		}
	}
	
}
