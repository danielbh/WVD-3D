using UnityEngine;
using System.Collections;

public class PassIfObjectWithNameInScene: MonoBehaviour {

    public string objectName;
    public float waitTimeInSeconds = 0.5f;

	// Use this for initialization
	void OnEnable ()
    {
        Invoke("CheckIfObjectInScene", waitTimeInSeconds);
    }

    void CheckIfObjectInScene()
    {
        if (GameObject.Find(objectName) != null)
        {
            IntegrationTest.Pass();
        }
        // If object is generated it will have (Clone) appended to the end.
        else if (GameObject.Find(objectName + "(Clone)") != null)
        {
            IntegrationTest.Pass();
        }
        else
        {
            IntegrationTest.Fail();
        }
    }
}
