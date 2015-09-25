using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable]
public class PlayerController : HumanoidController {

	public IMoveComponent moveComponent;

	private Vector3	worldMoveVec;	// current world-space movement vector (per second)
	private float 	orientVel;		// current smoothing velocity
	private float	orientCur,		// current character orientation
	orientTarget;	// target orientation used for smoothing

	public void FaceDir(float angle, float pow, float aimStickDeadZone, float aimStickMinSpeed, float aimStickMaxSpeed, 
	                    float maxTurnSpeed, float turnSmoothingTime)
	{
			// TODO: See if you can make more concise
			// Dead zone is the zone that caues no movement
			if ((pow > aimStickDeadZone) && (pow > 0.0001f))
			{
				
				float lockingSpeed = Mathf.Clamp01((pow - aimStickDeadZone) / 
				                                   (1.0f - aimStickDeadZone));
	
				orientTarget = Mathf.MoveTowardsAngle(orientTarget,
				                                           angle, Time.deltaTime * 
				                                           Mathf.Lerp(aimStickMinSpeed, aimStickMaxSpeed, lockingSpeed));	
			}
			
			// Smooth character's orientation...
			orientCur = Mathf.SmoothDampAngle(orientCur, 	
			                                       orientTarget, ref orientVel, turnSmoothingTime  * 0.2f, 
			                                       maxTurnSpeed);

			moveComponent.FaceDir(Quaternion.Euler(0, orientCur, 0));
	}

	public void SetMoveComponent (IMoveComponent component) {
		moveComponent = component;
	}
	
	public void Move(Vector3 worldDir, float speed, float fwd, float bkwd, float side) {

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
			moveComponent.Move (worldMoveVec);
	}
	
	private Vector3 RotateVec(Vector3 vec, float angle)
	{
		return Quaternion.Euler(0, angle, 0) * vec;
	}
}
