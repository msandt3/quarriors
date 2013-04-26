using UnityEngine;
using System.Collections;

public class GUIChoiceWindows : MonoBehaviour {
	
	Player p;
	
	bool showDefenceWindow;
	bool showBuyWindow;
	bool showSummonWindow;
	bool showCullCheckWindow;
	
	
	//this is the waiting variable
	int choiceNumber;
	
	
	Rect cullCheckRect;
	
	// Use this for initialization
	void Start () {
		showDefenceWindow = false;
		showBuyWindow = false;
		showSummonWindow = false;
		showCullCheckWindow = false;
		cullCheckRect = ScreenCenterRect(300,150);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.P)){
			showCullCheckWindow=!showCullCheckWindow;
		}
		
	}
	
	void OnGUI(){
		if(showCullCheckWindow)	cullCheckRect = GUI.Window(0,cullCheckRect,DrawYesNoWindow,"Would you like to Cull a Die?");
		
		
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
			
			
			
			
			
	}
				
			
	
			
	Rect ScreenCenterRect(int width, int height){
				return new Rect((Screen.width/2)-(width/2),(Screen.height/2)-(height/2),width,height);
	}
}
