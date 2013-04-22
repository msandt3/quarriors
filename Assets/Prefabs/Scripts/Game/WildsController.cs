using UnityEngine;
using System.Collections;

public class WildsController : MonoBehaviour {
	
	public GameObject basic;
	private GameObject BasicContainer;
	public GameObject SpellContainer;
	public GameObject CreatureContainer;
	public Wilds GameWilds;
	// Use this for initialization
	void Start () {
		BasicContainer = (GameObject)Instantiate(basic);
		BasicContainer.transform.position = new Vector3(0,-5,0);
		GameWilds = new Wilds(BasicContainer);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
