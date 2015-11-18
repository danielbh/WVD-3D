using UnityEngine;
using System.Collections;

public class VerifyPlayerLookingAtTeleportPoint : MonoBehaviour {

    public Vector2 screenInputPosition;
    public Vector3 worldOutputPosition;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject testObj = GameObject.CreatePrimitive(PrimitiveType.Cube);

        testObj.transform.position = player.transform.position;
        testObj.transform.LookAt(worldOutputPosition);

        player.GetComponent<PlayerMagic>().Teleport(screenInputPosition);

        if (Quaternion.Angle(player.transform.rotation, testObj.transform.rotation) == 0)
        {

            IntegrationTest.Pass();
        }
        else
        {
            print(Quaternion.Angle(player.transform.rotation, testObj.transform.rotation));

            IntegrationTest.Fail();
        }
    }
}
