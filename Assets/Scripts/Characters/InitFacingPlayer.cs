using UnityEngine;
using System.Collections;

public class InitFacingPlayer : MonoBehaviour {

	Transform player;

	void OnEnable() {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		transform.LookAt(player);
	}

}
