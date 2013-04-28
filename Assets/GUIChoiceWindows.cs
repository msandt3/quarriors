using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GUIChoiceWindows : MonoBehaviour {
	
	Player p;
	
	bool isDefenceWindow;
	bool isBuyWindow;
	bool isSummonWindow;
	bool isCullCheckWindow;
	bool isResolveWindow;
	bool isCullWindow;
	
	//this is the waiting variable
	public int choiceNumber;
	
	//Functions will return DONE_CHOICE if DONE_CHOICE is selected
	private static int WAITING=-100;
	private static int DONE = -1;
	private static int YES = 1;
	private static int NO = 0;
	
	Rect cullCheckRect;
	Rect buyWindowRect;
	Rect resolveRect;
	Rect cullRect;
	Rect summonRect;
	Rect defenceRect;
	Rect buyRect;
	
	public bool hasChosen;
	private Dictionary<string,string> diceNameTable;
	
	bool yesNoResult;
	
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
		cullCheckRect = ScreenCenterRect(300,150);
		resolveRect = ScreenCenterRect(500,400);
		cullRect = ScreenCenterRect(500,400);
		summonRect = ScreenCenterRect(500,400);
		defenceRect = ScreenCenterRect(500,400);
		buyRect = ScreenCenterRect(500,400);
		scrollViewVector = Vector2.zero;
		SetUpTagDictionary();
	}
	
	// Update is called once per frame
	void Update () {
//		if(Input.GetKeyDown(KeyCode.P)){
//			isCullCheckWindow=!isCullCheckWindow;
//		}
//		if(Input.GetKeyDown(KeyCode.B)){
//			isResolveWindow=!isResolveWindow;			
//		}
		
	}
	
	void OnGUI(){
		if(isCullCheckWindow)	cullCheckRect = GUI.Window(0,cullCheckRect,DrawYesNoWindow,"Would you like to Cull a Die?");
		if(isResolveWindow) resolveRect = GUI.Window(1,resolveRect,DiceChoiceWindow, "Choose a dice to resolve...");
		if(isCullWindow) cullRect = GUI.Window(1,cullRect,DiceChoiceWindow, "Choose a dice to cull...");
		if(isSummonWindow) summonRect = GUI.Window(1,summonRect,DiceChoiceWindow, "Choose a creature to Summon...");
		if(isDefenceWindow) defenceRect = GUI.Window(1,defenceRect,DiceChoiceWindow, "Choose a creature to Defend with...");
		if(isBuyWindow) buyRect = GUI.Window(1,buyRect,DiceChoiceWindow, "Choose a die from the wilds to buy...");
		
	}
		
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
				
			
	
			
	Rect ScreenCenterRect(int width, int height){
				return new Rect((Screen.width/2)-(width/2),(Screen.height/2)-(height/2),width,height);
	}
	
	
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
	
	//Dice windows return null if waiting, GUIChoiceWindows.DONE_CHOICE if done button, and appropriate Die if Die was selected.
	
	
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
		
		
	
}