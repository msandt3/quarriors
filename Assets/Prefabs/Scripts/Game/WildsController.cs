using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WildsController : MonoBehaviour {
	
	public GameObject basic;
	private GameObject BasicContainer;
	public GameObject spell;
	private GameObject SpellContainer;
	public GameObject creature;
	private GameObject CreatureContainer;
	public Wilds GameWilds;
	// Use this for initialization
	void Start () {
		
		/** Set up the Basic Cards **/
		BasicContainer = (GameObject)Instantiate(basic);
		BasicContainer.transform.position = new Vector3(0,10,0);
		GameWilds = new Wilds(BasicContainer);
		
		/** Set up the Spell Cards **/
		setUpSpells ();
		
		/** Set up the Creature Cards **/
		setUpCreatures();
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void setUpSpells(){
		SpellContainer = new GameObject();
		
		List<Transform> cards = new List<Transform>();
		foreach(Transform child in spell.transform){
			cards.Add(child);
		}
		
		shuffle (cards);
		
		for(int i=0; i<3; i++){
			Transform clone = (Transform)Instantiate (cards[i]);
			clone.parent = SpellContainer.transform;
			clone.transform.position = new Vector3((i-1)*7,0,0);
		}
		
		foreach(Transform child in SpellContainer.transform){
			Debug.Log(child.ToString ());
		}
		
		
	}
	
	void setUpCreatures(){
		CreatureContainer = new GameObject();
		
		List<Transform> cards = new List<Transform>();
		foreach(Transform child in creature.transform){
			cards.Add(child);
		}
		
		shuffle (cards);
		
		for(int i=0; i<5; i++){
			Transform clone = (Transform)Instantiate (cards[i]);
			clone.parent = CreatureContainer.transform;
			clone.transform.position = new Vector3((i-3)*7,-10,0);
		}
		
		foreach(Transform child in SpellContainer.transform){
			Debug.Log(child.ToString ());
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
