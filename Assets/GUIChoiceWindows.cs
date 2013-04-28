using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GUIChoiceWindows : MonoBehaviour {
	
	//Player p;
	
	//Window Showing booleans
	bool isDefenceWindow;
	bool isBuyWindow;
	bool isSummonWindow;
	bool isCullCheckWindow;
	bool isResolveWindow;
	bool isCullWindow;
	bool isShowDiceWindow;
	
	//this is the waiting variable
	public int choiceNumber;
	
	//static variables used in determining state of window
	private static int WAITING=-100;
	private static int DONE = -1;
	private static int YES = 1;
	private static int NO = 0;
	
	//Rects for remembering window Positioning
	Rect cullCheckRect;
	Rect buyWindowRect;
	Rect resolveRect;
	Rect cullRect;
	Rect summonRect;
	Rect defenceRect;
	Rect buyRect;
	Rect showDiceRect;
	
	//IMPORTANT BOOLEAN: used to see if someone has made a choice....to be used in GameEngine
	//(see GUITestingScript for example on use);
	public bool hasChosen;
	private Dictionary<string,string> diceNameTable;
	
	bool yesNoResult;
	
	//holds the current list of dice shown on the GUI
	List<Die> displayedDie;
	
	Vector2 scrollViewVector;
	
	// Use this for initialization
	void Start () {
		isDefenceWindow = false;
		isBuyWindow = false;
		isSummonWindow = false;
		isCullCheckWindow = false;
		isCullWindow = false;
		isResolveWindow = false;
		isShowDiceWindow = false;
		cullCheckRect = ScreenCenterRect(300,150);
		resolveRect = ScreenCenterRect(500,400);
		cullRect = ScreenCenterRect(500,400);
		summonRect = ScreenCenterRect(500,400);
		defenceRect = ScreenCenterRect(500,400);
		buyRect = ScreenCenterRect(500,400);
		showDiceRect = ScreenCenterRect(500,400);
		scrollViewVector = Vector2.zero;
		SetUpTagDictionary();
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	//Main GUI Function...If window's bool is active then appears 
	void OnGUI(){
		if(isCullCheckWindow)	cullCheckRect = GUI.Window(0,cullCheckRect,DrawYesNoWindow,"Would you like to Cull a Die?");
		if(isResolveWindow) resolveRect = GUI.Window(1,resolveRect,DiceChoiceWindow, "Choose a dice to resolve...");
		if(isCullWindow) cullRect = GUI.Window(1,cullRect,DiceChoiceWindow, "Choose a dice to cull...");
		if(isSummonWindow) summonRect = GUI.Window(1,summonRect,DiceChoiceWindow, "Choose a creature to Summon...");
		if(isDefenceWindow) defenceRect = GUI.Window(1,defenceRect,DiceChoiceWindow, "Choose a creature to Defend with...");
		if(isBuyWindow) buyRect = GUI.Window(1,buyRect,DiceChoiceWindow, "Choose a die from the wilds to buy...");
		if(isShowDiceWindow) showDiceRect = GUI.Window(1,showDiceRect,DiceShowWindow,"Showing Dice...");
		
	}
	
	
	//Window function to create the inside of the Yes/No Windows. More window labels will have be added for different
	//Yes/No Buttons
	void DrawYesNoWindow(int windowID){
		if(windowID == 0){
			GUI.Label(new Rect(110,30,80,30),"Die To Cull: ");
			if(GUI.Button(new Rect(50,110,80,30), "Cull Die")){
				yesNoResult = true;
				choiceNumber = DONE;
			}
			if(GUI.Button(new Rect(170,110,80,30), "Done")){
				yesNoResult = false;
				choiceNumber = DONE;
			}
			
		}	
		GUI.DragWindow (new Rect (0,0, 10000, 20));	
	}
	
	//Window function to create the inside of the Dice Choice windows. Similar across all windows
	void DiceChoiceWindow(int windowID){
		int diceCount = displayedDie.Count;
		if(windowID == 1){
			scrollViewVector=GUI.BeginScrollView(new Rect(20,20,400,250),scrollViewVector,new Rect(0,0,300,(diceCount*40)));
			for(int i=0; i<diceCount; i++){
				int curSide = displayedDie[i].SideList.IndexOf(displayedDie[i].ActiveSide);
				if(GUI.Button(new Rect(0,(i*40),300,30),diceNameTable[displayedDie[i].tag] +": Side "+curSide)){
					choiceNumber=i;
				}
			}
			
			
			GUI.EndScrollView();
			if(GUI.Button(new Rect(20,280,50,30),"Done")){
				choiceNumber = DONE;
			}
		}
			
			
			
		GUI.DragWindow (new Rect (0,0, 10000, 20));	
	}
	
	void DiceShowWindow(int windowID){
		int diceCount = displayedDie.Count;
		if(windowID == 1){
			scrollViewVector=GUI.BeginScrollView(new Rect(20,20,400,250),scrollViewVector,new Rect(0,0,300,(diceCount*40)));
			for(int i=0; i<diceCount; i++){
				int curSide = displayedDie[i].SideList.IndexOf(displayedDie[i].ActiveSide);
				GUI.Box(new Rect(0,(i*40),300,30),diceNameTable[displayedDie[i].tag] +": Side "+curSide);				
			}
			
			
			GUI.EndScrollView();
			if(GUI.Button(new Rect(20,280,50,30),"Done")){
				choiceNumber = DONE;
			}
		}
			
			
			
		GUI.DragWindow (new Rect (0,0, 10000, 20));	
		
		
		
	}
				
			
	
	//Centers a window to the screen		
	Rect ScreenCenterRect(int width, int height){
				return new Rect((Screen.width/2)-(width/2),(Screen.height/2)-(height/2),width,height);
	}
	
	//building tag to card name library for GUI purposes
	void SetUpTagDictionary(){
		diceNameTable = new Dictionary<string, string>();
		diceNameTable.Add("BQ","Basic Quiddity");
		diceNameTable.Add("A","Assistant");	
		diceNameTable.Add("P","Portal");
		diceNameTable.Add("WH","Witching Hag");
		diceNameTable.Add("SG","Scavenging Goblin");
		diceNameTable.Add("GS","Ghostly Spirit");
		diceNameTable.Add("DHQ","Devotee Of The Holy Query");
		diceNameTable.Add("PO","Primordial Ooze");
		diceNameTable.Add("WQ","Warrior Of The Quay");
		diceNameTable.Add("QD","Quake Dragon");
		diceNameTable.Add("DD","Deathdealer");
		diceNameTable.Add("QW","Questing Wizard");
		diceNameTable.Add("DP","Defender Of The Pale");
		diceNameTable.Add("S","Shaping Incantation");
		diceNameTable.Add("G","Growth Incantation");
		diceNameTable.Add("D","Death Incantation");
		diceNameTable.Add("V","Victory Incantation");
		diceNameTable.Add("L","Life Incantation");
		
	}
	
	
	
	//The following are the actual functions to be used in the GameEngine class, each will generate an interface 
	// and return a value
	
	//There are two kinds of windows, Yes/No Windows for simple prompts and Dice Show Windows for dice selection.
	
	//All Dice window functions return a Die and follow the same call format:  showXWindow(List<Die> dieToDisplay)
	
	//All Yes/No window functions return a bool and follow the same call format: showXWindow();
	
	
	//see GUITestingScript Class for examples on how to use
	
	public Die showResolveWindow(List<Die> dieToDisplay){
		displayedDie = dieToDisplay;
		if(!isResolveWindow){
			scrollViewVector = Vector2.zero;
			isResolveWindow = true;
			hasChosen = false;
			choiceNumber = WAITING;
		}
		if(choiceNumber == WAITING){
			return null;
		}
		else if(choiceNumber==DONE){
			isResolveWindow = false;
			hasChosen = true;
			return null;
		}
		else if(choiceNumber >=0){
			isResolveWindow = false;
			hasChosen = true;
			return displayedDie[choiceNumber];
		}
		else{
			return null;
		}
		
	}
	
	
	
	public bool showCullCheck(){
		if(!isCullCheckWindow){
			isCullCheckWindow= true;
			choiceNumber = WAITING;
			hasChosen = false;
		}
		if(choiceNumber == DONE){
			isCullCheckWindow = false;
			hasChosen = true;
			return yesNoResult;
		}
		else{
			return false;
		}
		
	}
	
	public Die showCullWindow(List<Die> dieToDisplay){
		displayedDie = dieToDisplay;
		if(!isCullWindow){
			scrollViewVector = Vector2.zero;
			isCullWindow = true;
			hasChosen = false;
			choiceNumber = WAITING;
		}
		if(choiceNumber == WAITING){
			return null;
		}
		else if(choiceNumber==DONE){
			isCullWindow = false;
			hasChosen = true;
			return null;
		}
		else if(choiceNumber >=0){
			isCullWindow = false;
			hasChosen = true;
			return displayedDie[choiceNumber];
		}
		else{
			return null;
		}
		
	}
	
	public Die showSummonWindow(List<Die> dieToDisplay){
		displayedDie = dieToDisplay;
		if(!isSummonWindow){
			scrollViewVector = Vector2.zero;
			isSummonWindow = true;
			hasChosen = false;
			choiceNumber = WAITING;
		}
		if(choiceNumber == WAITING){
			return null;
		}
		else if(choiceNumber==DONE){
			isSummonWindow = false;
			hasChosen = true;
			return null;
		}
		else if(choiceNumber >=0){
			isSummonWindow = false;
			hasChosen = true;
			return displayedDie[choiceNumber];
		}
		else{
			return null;
		}
		
	}
	
	public Die showDefenseWindow(List<Die> dieToDisplay){
		displayedDie = dieToDisplay;
		if(!isDefenceWindow){
			scrollViewVector = Vector2.zero;
			isDefenceWindow = true;
			hasChosen = false;
			choiceNumber = WAITING;
		}
		if(choiceNumber == WAITING){
			return null;
		}
		else if(choiceNumber==DONE){
			isDefenceWindow = false;
			hasChosen = true;
			return null;
		}
		else if(choiceNumber >=0){
			isDefenceWindow = false;
			hasChosen = true;
			return displayedDie[choiceNumber];
		}
		else{
			return null;
		}
		
	}
	
	public Die showBuyWindow(List<Die> dieToDisplay){
		displayedDie = dieToDisplay;
		if(!isBuyWindow){
			scrollViewVector = Vector2.zero;
			isBuyWindow = true;
			hasChosen = false;
			choiceNumber = WAITING;
		}
		if(choiceNumber == WAITING){
			return null;
		}
		else if(choiceNumber==DONE){
			isBuyWindow = false;
			hasChosen = true;
			return null;
		}
		else if(choiceNumber >=0){
			isBuyWindow = false;
			hasChosen = true;
			return displayedDie[choiceNumber];
		}
		else{
			return null;
		}
		
	}
	
	//This function shows Dice with no interactivity...besides done button
	public void showDiceViewWindow(List<Die> dieToDisplay){
		displayedDie = dieToDisplay;
		if(!isShowDiceWindow){
			scrollViewVector = Vector2.zero;
			isShowDiceWindow = true;
			hasChosen = false;
			choiceNumber = WAITING;
		}
		if(choiceNumber==DONE){
			isShowDiceWindow = false;
			hasChosen = true;
		}
		
	}
		
		
	
}