using UnityEngine;
using System.Collections;

public class LocationZoom : MonoBehaviour {
	public GameObject toDisplay;
	public GameObject location;
	private GameObject clone;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnMouseEnter() {
		clone = Instantiate(toDisplay, location.transform.position + new Vector3(0f,0f,-0.5f), location.transform.rotation) as GameObject;
		clone.transform.localScale = new Vector3(45f,10.25f,1f);
		//Debug.Log ("In");
	}
	
	void OnMouseExit() {
		Destroy (clone);
		//Debug.Log ("Out");
	}
}
