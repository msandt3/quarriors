using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GUITestingScript : MonoBehaviour {
	
	bool startTest;
	
	List<Die> dice;
	
	public GUIChoiceWindows gui;
	
	// Use this for initialization
	void Start () {
		startTest = false;
		dice = new List<Die>();
		dice.Add(new Die("BQ"));
		dice.Add(new Die("A"));
		dice.Add(new Die("P"));
		dice.Add(new Die("WH"));
		dice.Add(new Die("SG"));
		dice.Add(new Die("GS"));
		dice.Add(new Die("WH"));
		dice.Add(new Die("SG"));
		dice.Add(new Die("GS"));
		dice.Add(new Die("WH"));
		dice.Add(new Die("SG"));
		dice.Add(new Die("GS"));
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.P)){
			startTest=!startTest;
		}
		
		
		if(startTest){
			
			ResolveWindowTest();
			
			
		}
		
	}
	
	public void ResolveWindowTest(){
		//calling window call every frame
		Die d = gui.showResolveWindow(dice);
		if(gui.hasChosen){
			if(d == null){
				Debug.Log("Player is done with current window...");
				Debug.Log("Concluding test");
				startTest = false;
			}
			else{
				Debug.Log("Player select a die: "+ d.tag);
				Debug.Log("Concluding test");
				startTest = false;
			}
		}
	}
	
	public void CullCheckWindowTest(){
		bool confirmCull = gui.showCullCheck();
		if(gui.hasChosen){
			if(confirmCull){
				Debug.Log("ConfirmCull");
				startTest = false;
			}
			else{
				Debug.Log("DenyCull");
				startTest = false;
			}
		}
		
	}
	
	
	
	
}
