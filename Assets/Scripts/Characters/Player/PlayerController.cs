using UnityEngine;
using System;

[Serializable]
public class PlayerController : HumanoidController {

	public IMoveComponent moveComponent;

	private Vector3	worldMoveVec;	// current world-space movement vector (per second)
	private float 	orientVel;		// current smoothing velocity
	private float	orientCur,		// current character orientation
	orientTarget;	// target orientation used for smoothing


	
	public void SetMoveComponent (IMoveComponent component) {
		moveComponent = component;
	}
	
	public void Move(Vector3 worldDir, float speed) {
		
		if (Mathf.Clamp01(speed) < 0.001f)
		{
			// Stop.
			worldMoveVec = Vector3.zero;
		}
		else
		{
			// Transform world vec to local space...
			Vector3 localDir = RotateVec(worldDir, -orientCur);
			
			// Apply Forward/Back/Side speed modifiers...
			
			if (localDir.z > 0) 
				localDir.z *= runForwardSpeed;
			else
				localDir.z *= runBackSpeed;
			
			localDir.x *= runSideSpeed;
			
			// Transform back to world space...
			
			worldMoveVec = RotateVec(localDir * speed, orientCur);
			
			moveComponent.Move (worldMoveVec);
		}
	}
	
	private Vector3 RotateVec(Vector3 vec, float angle)
	{
		return Quaternion.Euler(0, angle, 0) * vec;
	}
}
