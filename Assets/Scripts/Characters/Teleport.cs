using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour {

	GameObject player;
	
	void OnEnable()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	void Update () {
	
	}
    
}
