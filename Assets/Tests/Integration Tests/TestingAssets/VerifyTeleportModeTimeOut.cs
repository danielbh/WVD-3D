using UnityEngine;
using System.Collections;

public class VerifyTeleportModeTimeOut : MonoBehaviour
{

    public float delayTestInSeconds = 0.2f;
    TouchStick[] touchSticks;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        touchSticks = player.GetComponent<Player>().touchController.sticks;

        player.GetComponent<PlayerMagic>().CastTeleportSpell();

        Invoke("Test", delayTestInSeconds);
    }

    void Test()
    {
        if (touchSticks[0].Enabled() == true && touchSticks[1].Enabled() == true)
        {
            IntegrationTest.Pass();
        }
        else
        {
            IntegrationTest.Fail();
        }
    }
}
