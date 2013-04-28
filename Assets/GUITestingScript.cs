using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GUITestingScript : MonoBehaviour {
	
	bool startTest;
	
	List<Die> dice;
	
	public GUIChoiceWindows gui;
	
	// Use this for initialization
	//Generating a sample set of dice
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
		//Key press to start a GUI Popup test
		if(Input.GetKeyDown(KeyCode.P)){
			startTest=!startTest;
		}
		
		
		if(startTest){
			
			//Replace any kind of window function here to test
			ResolveWindowTest();
			
			
		}
		
	}
	
	//Test example of how to use a Dice Window in code.
	public void ResolveWindowTest(){
		//calling window call every frame to see what value is
		//the variable dice is the set of dice you want displayed to the player
		Die d = gui.showResolveWindow(dice);
		
		//gui.hasChosen changes to true once a person has performed an choice action with the window
		if(gui.hasChosen){
			//In the case of a dice window, null means that the player has chosen the "Done" option
			if(d == null){
				Debug.Log("Player is done with current window...");
				Debug.Log("Concluding test");
				startTest = false;
			}
			//Anything else is considered a return of a die (from the set "dice" sent in to the window)
			else{
				Debug.Log("Player select a die: "+ d.tag);
				Debug.Log("Concluding test");
				startTest = false;
			}
		}
	}
	
	public void CullCheckWindowTest(){
		bool confirmCull = gui.showCullCheck();
		//gui.hasChosen changes to true once a person has performed an choice action with the window
		if(gui.hasChosen){
			//In the case of a Yes/No window true is Yes
			if(confirmCull){
				Debug.Log("ConfirmCull");
				startTest = false;
			}
			//Else is no
			else{
				Debug.Log("DenyCull");
				startTest = false;
			}
		}
		
	}
	
	
	
	
}
