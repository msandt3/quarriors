using UnityEngine;
using System.Collections;

public class CardSlideLeft : MonoBehaviour {
	public GameObject cardArea;
	public int speed = 20;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseOver() {
		cardArea.transform.Translate (Vector3.left*Time.deltaTime*speed);
	}
}
