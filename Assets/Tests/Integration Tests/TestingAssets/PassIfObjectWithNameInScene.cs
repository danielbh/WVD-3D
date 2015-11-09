using UnityEngine;
using System.Collections;

public class PassIfObjectWithNameInScene: MonoBehaviour {

    public string objectName;
    public float delayInSeconds = 0.5f;

	// Use this for initialization
	void OnEnable ()
    {
        Invoke("CheckIfObjectInScene", delayInSeconds);
    }

    void CheckIfObjectInScene()
    {
        // If object is generated it will have (Clone) appended to the end.
        GameObject obj = GameObject.Find(objectName + "(Clone)");
        if (obj != null)
        {
            IntegrationTest.Pass();
            // Removes object so doesn't pollute future tests.
            Destroy(obj);
        }
        else
        {
            IntegrationTest.Fail();
        }
    }
}
