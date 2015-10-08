using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable]
public class ActionController {
	
	private Vector3	worldMoveVec;	// current world-space movement vector (per second)

	public Vector3 Move(Vector3 worldDir, float speed, float fwd, float bkwd, float side) {	

			// Transform world vec to local space...
			Vector3 localDir = RotateVec(worldDir);
			
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
			worldMoveVec = RotateVec(localDir * speed);

			return worldMoveVec;
	}

	private Vector3 RotateVec(Vector3 vec)
	{
		return Quaternion.Euler(0, 0, 0) * vec;
	}
}
