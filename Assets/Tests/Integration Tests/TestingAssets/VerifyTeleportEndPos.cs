using UnityEngine;
using System.Collections;

public class VerifyTeleportEndPos : MonoBehaviour {
    public Vector2 screenInputPosition;
    public Vector3 worldOutputPosition;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        player.GetComponent<PlayerMagic>().Teleport(screenInputPosition);

        float dist = Vector3.Distance(player.transform.position, worldOutputPosition);

        if (dist < 0.001f)
        {
            IntegrationTest.Pass();
        }
        else
        {
            IntegrationTest.Fail();
        }
    }
}
