using UnityEngine;
using System.Collections;

public class DestroyIfTargetNull : MonoBehaviour {

    public float checkFrequency = 0.1f;

    public void SetTarget(GameObject target)
    {
        StartCoroutine(CheckIfTargetExists(target, checkFrequency));
    }

    IEnumerator CheckIfTargetExists(GameObject target, float interval)
    {
        for (;;)
        {
            if (target == null)
            {
                Destroy(gameObject);
            }
            yield return new WaitForSeconds(interval);
        }
    }
}
