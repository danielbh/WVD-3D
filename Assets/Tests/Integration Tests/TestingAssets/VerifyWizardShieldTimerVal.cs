using UnityEngine;
using System.Collections;

public class VerifyWizardShieldTimerVal : MonoBehaviour {

    public GameObject shield;
    public float delayInSeconds;

    float initialVal;

    void Start ()
    {
        Invoke("Test", delayInSeconds);
    }

    void Test ()
    {
        initialVal = shield.GetComponent<WizardShield>().timer;

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerMagic>().CastWizardShieldSpell();

        float timer = shield.GetComponent<WizardShield>().timer;

        if (timer < initialVal)
        {
            IntegrationTest.Pass();
        }
        else
        {
            IntegrationTest.Fail();
        }
    }
}
