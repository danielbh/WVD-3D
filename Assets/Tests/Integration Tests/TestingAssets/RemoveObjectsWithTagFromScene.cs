using UnityEngine;
using System.Collections;

public class RemoveObjectsWithTagFromScene : MonoBehaviour {

    public float delayInSeconds = 2;
    public string objTag;

    void Start () {
        Invoke("Remove", delayInSeconds);
	}

    void Remove()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag(objTag);

        foreach(GameObject obj in objects)
        {
            Destroy(obj);
        }
    }
}
