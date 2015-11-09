using UnityEngine;
using System.Collections;

public class PassIfObjectWithNameRemoved : MonoBehaviour
{

    public string objectName;
    public float delayBeforeTestExists = 0.5f;
    public float delayBeforeTestRemoved = 2;

    string objectCloneName
    {
        get
        {
            return objectName + "(Clone)";
        }
    }

    void OnEnable()
    {
        Invoke("CheckIfObjectInScene", delayBeforeTestExists);
    }

    void CheckIfObjectInScene()
    {
        if (GameObject.Find(objectCloneName) == null)
        {
            IntegrationTest.Fail();
        }
        else
        {
            Invoke("CheckIfObjectRemoved", delayBeforeTestRemoved);
        }
    }

    void CheckIfObjectRemoved()
    {
        if (GameObject.Find(objectCloneName) == null)
        {
            IntegrationTest.Pass();
        }
        else
        {
            IntegrationTest.Fail();
        }
    }
}
