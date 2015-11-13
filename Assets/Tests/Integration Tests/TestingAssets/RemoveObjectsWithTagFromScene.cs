using UnityEngine;
using System.Collections;

public class RemoveObjectsWithTagFromScene : MonoBehaviour {

    public float delayInSeconds = 2;
    public string tag;

    void Start () {
        Invoke("Remove", delayInSeconds);
	}

    void Remove()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);

        foreach(GameObject obj in objects)
        {
            Destroy(obj);
        }
    }
}
