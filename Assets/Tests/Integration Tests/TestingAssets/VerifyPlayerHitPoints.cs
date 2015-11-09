using UnityEngine;
using System.Collections;

public class VerifyPlayerHitPoints : MonoBehaviour {

    public float delayPassInSeconds = 2;
    public int expectedHitPoints = 100;
    GameObject player;

    void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Invoke("Pass", delayPassInSeconds);
    }


    void Update ()
    {
        NCHealth health = player.GetComponent<NCHealth>();

        if (health.hitPoints != expectedHitPoints)
        {
            IntegrationTest.Fail();
        }
    }

    void Pass()
    {
      IntegrationTest.Pass();
    }
}
