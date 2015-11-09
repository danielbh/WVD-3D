using UnityEngine;
using System.Collections;

public class VerifyGameObjDoesNotMove : MonoBehaviour {

    public GameObject obj;
    public float delayPassInSeconds = 2;
    public float errorTolerance = 0.1f;

    Vector3 originalPos;

    // Use this for initialization
    void OnEnable()
    {
        originalPos = obj.transform.position;
        Invoke("Pass", delayPassInSeconds);
    }


    void Update()
    {
        Vector3 pos = obj.transform.position;

        if (Vector3.Distance(originalPos, pos) > errorTolerance)
        {
            IntegrationTest.Fail();
        }
    }

    void Pass()
    {
        IntegrationTest.Pass();
    }
}
