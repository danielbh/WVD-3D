using UnityEngine;
using System.Collections;
using System;

public class NCMonoBehaviour : MonoBehaviour {

	protected IEnumerator InvokeMethod(Action method, float interval, int invokeCount)
	{
		for (int i = 0; i < invokeCount; i++)
		{
			method();
			//print (i);
			yield return new WaitForSeconds(interval);
		}
	}
}
