using UnityEngine;
using System.Collections;

public class CountObjectsOfTypeInScene : MonoBehaviour {

    public string tagName;
    public int expected;
    public float delayInSeconds = 1;

    // Use this for initialization
    void Start()
    {
        Invoke("CountObjects", delayInSeconds);
    }

    void CountObjects()
    {
        int actual = GameObject.FindGameObjectsWithTag(tagName).Length;

        if (expected == actual)
        {
            IntegrationTest.Pass();
        }
        else
        {
            IntegrationTest.Fail();
        }

    }
}
