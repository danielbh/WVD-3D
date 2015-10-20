using UnityEngine;
using System.Collections;

public class IceBurstTestScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.gameObject.GetComponent<PlayerMagic>().CastIceBurstSpell();
    }

}
