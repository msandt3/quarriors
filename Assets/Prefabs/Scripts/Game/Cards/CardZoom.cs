using UnityEngine;
using System.Collections;


public class CardZoom : MonoBehaviour {
	public GameObject zoomArea;
	public GameObject image;
	private GameObject clone;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseEnter() {
		if(zoomArea != null){
			clone = Instantiate (image, zoomArea.transform.position + new Vector3(2.0f,0f,-0.5f), zoomArea.transform.rotation) as GameObject;
			clone.transform.localScale = new Vector3(20f,30f,1f);
		}
	}
	
	void OnMouseExit() {
		Destroy (clone);
	}
	
	public void setZoomArea(GameObject area){
		this.zoomArea = area;
	}
}
