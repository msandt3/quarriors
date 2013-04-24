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
	
	// Use this for initialization
	void Start () {
		SetUpBasic();
		SetUpSpells ();
		SetUpCreatures();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void SetUpBasic(){
		foreach(Transform basic in BasicDeck.transform){
			Transform card;
			card = Instantiate(basic) as Transform;
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
		
		for(int i=0; i<5; i++){
			Transform card;
			card = Instantiate(creatures[i]) as Transform;
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
}
