using UnityEngine;
using System.Collections;

public class VerifyIceBurstValues : MonoBehaviour {

    void Start () {
        AreaEffect iceBurst = GameObject.Find("Ice Burst").GetComponent<AreaEffect>();

        if (iceBurst.damage == 25 && iceBurst.radius == 5 && iceBurst.power == 10)
        {
            IntegrationTest.Pass();
        }
        else
        {
            IntegrationTest.Fail();
        }
    }
	
}
