using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable]
public class ActionController : HumanoidController {
	
	private Vector3	worldMoveVec;	// current world-space movement vector (per second)
	private float	orientCur;	// current character orientation
	
	public Vector3 Move(Vector3 worldDir, float speed, float fwd, float bkwd, float side) {

			// Transform world vec to local space...
			Vector3 localDir = RotateVec(worldDir, -orientCur);
			
			// Apply Forward/Back/Side speed modifiers. 

			if (localDir.z > 0) 
				// Run forward speed
				localDir.z *= fwd;
			else
				// Run backward speed
				localDir.z *= bkwd;

			// Run side speed
			localDir.x *= side;
			
			// Transform back to world space...
			worldMoveVec = RotateVec(localDir * speed, orientCur);
			return worldMoveVec;
	}
	
	private Vector3 RotateVec(Vector3 vec, float angle)
	{
		return Quaternion.Euler(0, angle, 0) * vec;
	}
}
