using UnityEngine;
using System.Collections;

public class IceBurstTestScript : NCMonoBehaviour {

    public int numOfTimesToCast = 1;
    GameObject player;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(InvokeMethod(Cast, 0, numOfTimesToCast));
    }

    void Cast()
    {
        player.gameObject.GetComponent<PlayerMagic>().CastIceBurstSpell();
    }
}
