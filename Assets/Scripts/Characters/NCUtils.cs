using UnityEngine;
using System.Collections;
using System;

public class NCUtils
{
	public static bool CheckIfMaxRangeTravelled(float range, Vector3 origin, Vector3 position) 
	{
		var travelled = Vector3.Distance(origin, position);
		return travelled >= range;
	}
}
