using UnityEngine;
using System.Collections;

public class LocationZoom : MonoBehaviour {
	public GameObject toDisplay;
	public GameObject location;
	private GameObject clone;
	public GUIChoiceWindows gcw;
	public GameEngine ge;
	public int pool;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnMouseEnter() {
		if (pool == 0) {
			gcw.showPoolWindow (true, ge.GameState.p1.ActivePool, "Active Pool P1");
		}
		else if (pool == 1) {
			gcw.showPoolWindow (true, ge.GameState.p1.ReadyArea, "Ready Area P1");
		}
		else if (pool == 2) {
			gcw.showPoolWindow (true, ge.GameState.p1.UsedPile, "Used Pile P1");
		}
		else if (pool == 3) {
			gcw.showPoolWindow (true, ge.GameState.p1.SpentPile, "Spent Pile P1");
		}
		else if (pool == 4) {
			gcw.showPoolWindow (true,ge.GameState.p2.ActivePool, "Active Pool CPU");
		}
		else if (pool == 5) {
			gcw.showPoolWindow (true,ge.GameState.p2.ReadyArea, "ReadyArea CPU");
		}
		else if (pool == 6) {
			gcw.showPoolWindow (true,ge.GameState.p2.UsedPile, "Used Pile CPU");
		}
		else {
			gcw.showPoolWindow (true,ge.GameState.p2.SpentPile, "Spent Pile CPU");
		}
		clone = Instantiate(toDisplay, location.transform.position + new Vector3(0f,0f,-0.5f), location.transform.rotation) as GameObject;
		clone.transform.localScale = new Vector3(45f,10.25f,1f);
		//Debug.Log ("In");
	}
	
	void OnMouseExit() {
		gcw.showPoolWindow (false);
		Destroy (clone);
		//Debug.Log ("Out");
	}
}
