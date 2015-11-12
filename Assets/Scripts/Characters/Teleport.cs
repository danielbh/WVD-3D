using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour {

	GameObject player;
	
	void Start()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// TODO: Goes into 'select player teleport location' mode
	// TODO: Once selected teleport to location
}
