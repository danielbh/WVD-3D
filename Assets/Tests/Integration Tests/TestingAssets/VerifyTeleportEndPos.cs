using UnityEngine;
using System.Collections;

public class VerifyTeleportEndPos : MonoBehaviour {
    public Vector3 firstInputPosition;
    public Vector3 firstOutputPosition;
    public Vector3 secondInputPosition;
    public Vector3 secondOutputPosition;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        player.GetComponent<PlayerMagic>().Teleport(firstInputPosition);

        if(player.transform.position != firstOutputPosition)
        {
            IntegrationTest.Fail();
        }

        //player.GetComponent<PlayerMagic>().Teleport(secondInputPosition);

        //if (player.transform.position == secondOutputPosition)
        //{
        //    IntegrationTest.Pass();
        //}
        //else
        //{
        //    IntegrationTest.Fail();
        //}

    }
}
