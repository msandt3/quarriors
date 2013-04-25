using UnityEngine;
using System.Collections;

public class CardSlideRight : MonoBehaviour {
	public GameObject cardArea;
	public int speed = 20;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseOver() {
		cardArea.transform.Translate (Vector3.right*Time.deltaTime*speed);
	}
}
