using UnityEngine;
using System.Collections;

public class GUIChoiceWindows : MonoBehaviour {
	
	Player p;
	
	bool showDefenceWindow;
	bool showBuyWindow;
	bool showSummonWindow;
	bool showCullCheckWindow;
	bool showResolveWindow;
	
	//this is the waiting variable
	int choiceNumber;
	
	
	Rect cullCheckRect;
	Rect buyWindowRect;
	Rect resolveRect;
	
	// Use this for initialization
	void Start () {
		showDefenceWindow = false;
		showBuyWindow = false;
		showSummonWindow = false;
		showCullCheckWindow = false;
		showResolveWindow = false;
		cullCheckRect = ScreenCenterRect(300,150);
		resolveRect = ScreenCenterRect(700,700);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.P)){
			showCullCheckWindow=!showCullCheckWindow;
		}
		if(Input.GetKeyDown(KeyCode.B)){
			showResolveWindow=!showResolveWindow;			
		}
		
	}
	
	void OnGUI(){
		if(showCullCheckWindow)	cullCheckRect = GUI.Window(0,cullCheckRect,DrawYesNoWindow,"Would you like to Cull a Die?");
		if(showResolveWindow) resolveRect = GUI.Window(1,resolveRect,DiceChoiceWindow, "Choose a dice to resolve...?");
		
	}
		
	void DrawYesNoWindow(int windowID){
		if(windowID == 0){
			GUI.Label(new Rect(110,30,80,30),"Die To Cull: ");
			if(GUI.Button(new Rect(50,110,80,30), "Cull Die")){
				choiceNumber = 1;
			}
			if(GUI.Button(new Rect(170,110,80,30), "Done")){
				choiceNumber = 1;
			}
			
		}	
		GUI.DragWindow (new Rect (0,0, 10000, 20));	
	}
	
	void DiceChoiceWindow(int windowID){
		if(windowID == 1){
			//add check to player active area
			
			
		}
			
			
			
		GUI.DragWindow (new Rect (0,0, 10000, 20));	
	}
				
			
	
			
	Rect ScreenCenterRect(int width, int height){
				return new Rect((Screen.width/2)-(width/2),(Screen.height/2)-(height/2),width,height);
	}
}
