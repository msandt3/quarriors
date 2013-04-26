using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CardAreaController : MonoBehaviour {
	
	public GameObject ZoomArea;
	public GameObject BasicDeck;
	public GameObject SpellDeck;
	public GameObject CreatureDeck;
	public GameObject CardArea;
	
	private float xStart = -25.0f;
	private float yStart = 0.0f;
	private int numCards = 0;
	//private CardZoom script;
	
	private List<Card> cards = new List<Card>();
	
	// Use this for initialization
	void Start () {
		SetUpBasic();
		SetUpSpells ();
		SetUpCreatures();
		foreach(Card card in cards){
			Debug.Log(card.ToString());
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void SetUpBasic(){
		foreach(Transform basic in BasicDeck.transform){
			Transform card;
			card = Instantiate(basic) as Transform;
			addCard(card);
			card.position = new Vector3(xStart + (10 * numCards), 0 , 0);
			card.parent = CardArea.transform;
			CardZoom script = card.gameObject.GetComponentInChildren<CardZoom>();
			script.setZoomArea(ZoomArea);
			numCards++;
		}
	}
	
	void SetUpSpells(){
		//initialize the list
		List<Transform> spells = new List<Transform>();
		foreach(Transform spell in SpellDeck.transform){
			spells.Add(spell);
		}
		
		shuffle (spells);
		
		for(int i=0; i<3; i++){
			Transform card;
			card = Instantiate(spells[i]) as Transform;
			addCard(card);
			card.position = new Vector3(xStart + (10 * numCards), 0 , 0);
			card.parent = CardArea.transform;
			CardZoom script = card.gameObject.GetComponentInChildren<CardZoom>();
			script.setZoomArea(ZoomArea);
			numCards++;
		}
	}
	
	void SetUpCreatures(){
		
		//initialize the list
		List<Transform> creatures = new List<Transform>();
		foreach(Transform creature in CreatureDeck.transform){
			creatures.Add(creature);
		}
		
		shuffle (creatures);
		
		for(int i=0; i<7; i++){
			Transform card;
			card = Instantiate(creatures[i]) as Transform;
			addCard(card);
			card.position = new Vector3(xStart + (10 * numCards), 0 , 0);
			card.parent = CardArea.transform;
			CardZoom script = card.gameObject.GetComponentInChildren<CardZoom>();
			script.setZoomArea(ZoomArea);
			numCards++;
		}
	}
	
	void shuffle(List<Transform> list){
		for(int i=list.Count-1; i>0; i--){
			int j = Random.Range(0,i+1);
			swap (list,i,j);
		}
	}
	
	void swap(List<Transform> list, int i, int j){
		Transform temp = list[i];
		list[i] = list[j];
		list[j] = temp;
	}

	void addCard(Transform card){
		switch(card.name){
		case "AssistantCard(Clone)":
			cards.Add(new AssistantCard());
			break;
		case "QuiddityCard(Clone)":
			cards.Add(new QuiddityCard());
			break;
		case "PortalCard(Clone)":
			cards.Add(new PortalCard());
			break;
		case "DeathDealerCard(Clone)":
			cards.Add(new DeathDealerCard());
			break;
		case "DefenderCard(Clone)":
			cards.Add(new DefenderCard());
			break;
		case "DevoteeCard(Clone)":
			cards.Add(new DevoteeCard());
			break;
		case "DragonCard(Clone)":
			cards.Add(new DragonCard());
			break;
		case "GoblinCard(Clone)":
			cards.Add(new GoblinCard());
			break;
		case "HagCard(Clone)":
			cards.Add(new HagCard());
			break;
		case "OozeCard(Clone)":
			cards.Add(new OozeCard());
			break;
		case "SpiritCard(Clone)":
			cards.Add (new SpiritCard());
			break;
		case "WarriorCard(Clone)":
			cards.Add(new WizardCard());
			break;
		case "WizardCard(Clone)":
			cards.Add(new WizardCard());
			break;
		case "DeathSpellCard(Clone)":
			cards.Add(new DeathSpellCard());
			break;
		case "GrowthSpellCard(Clone)":
			cards.Add(new GrowthSpellCard());
			break;
		case "LifeSpellCard(Clone)":
			cards.Add(new LifeSpellCard());
			break;
		case "ShapingSpellCard(Clone)":
			cards.Add(new ShapingSpellCard());
			break;
		case "VictorySpellCard(Clone)":
			cards.Add(new VictorySpellCard());
			break;
			
		}
	}
}
