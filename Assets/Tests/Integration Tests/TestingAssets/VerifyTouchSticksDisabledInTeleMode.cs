using UnityEngine;
using System.Collections;

public class VerifyTouchSticksDisabledInTeleMode : MonoBehaviour {

	void Start () {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        TouchStick[] touchSticks = player.GetComponent<Player>().touchController.sticks;

        player.GetComponent<PlayerMagic>().CastTeleportSpell();

        if (touchSticks[0].Enabled() == false && touchSticks[1].Enabled() == false)
        {
            IntegrationTest.Pass();
        }
        else
        {
            IntegrationTest.Fail();
        }
    }
}
