using UnityEngine;
using System.Collections;

public class ConcussiveBlastTestScript : MonoBehaviour {
	
	void Start () {
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		player.gameObject.GetComponent<PlayerMagic>().CastConcussiveBlastSpell();
	}
}
