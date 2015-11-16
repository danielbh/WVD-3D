using UnityEngine;
using System.Collections;

public class WizardShieldTestScript : MonoBehaviour {

	void Start () {
       GameObject player = GameObject.FindGameObjectWithTag("Player");

        player.GetComponent<PlayerMagic>().CastWizardShieldSpell();
	}
	
}
