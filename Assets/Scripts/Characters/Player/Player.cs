using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour, IMoveComponent {
	
	public const int STICK_MOVE	= 0;
	public const int STICK_FIRE	= 1;
	
	public	float	aimStickDeadZone	= 0.2f;
	public	float	aimStickMinSpeed	= 0.0f;		// aim locking speed just above dead zone (degs/sec) 
	public  float	aimStickMaxSpeed	= 500.0f;	// aim locking speed at maximum stick tilt (degs/sec)
	
	public	float	maxTurnSpeed		= 500.0f;	// max turn smoothing speed 
	public	float	turnSmoothingTime	= 0.3f;		// turn smoothing time
	
	[HideInInspector]
	public PlayerController playerController; // Test wrapper neccesary for making code testable
	public TouchController	touchController; // Input controller for player actions (ex: move, fire, etc...)
	
	public	float	runForwardSpeed		= 6.0f,		// max speed when running forward
	runSideSpeed		= 4.0f,		// max speed when running to the side
	runBackSpeed		= 3.0f;		// max speed when running back

	public Dictionary<string, float> directionSpeeds;

	private CharacterController	charaController;	
	
	private TouchStick fireStick;
	private TouchStick moveStick;
	
	public void OnEnable()
	{
		charaController = gameObject.GetComponent<CharacterController>();
		playerController.SetMoveComponent(this);

		moveStick	= touchController.GetStick(STICK_MOVE);
		fireStick	= touchController.GetStick(STICK_FIRE);
	}
	
	public void Update() 
	{
		if (touchController != null)
		{

			if (moveStick.Pressed())
			{	
				// Use stick's normalized XZ vector and tilt to move...
				playerController.Move(moveStick.GetVec3d(true, 0), moveStick.GetTilt());

//				if (!fireStick.Pressed()) {
//					Aim(moveStick.GetAngle(), moveStick.GetTilt());
//				}
			}
			
//			// Stop when stick is released...
//			else
//			{
//				Move(Vector3.zero, 0);
//			}
//
//			if (fireStick.Pressed())
//			{
//				// Get target angle and stick's tilt to determinate turning speed.
//				Aim(fireStick.GetAngle(), fireStick.GetTilt());
//			}
//			
//			// Don't aim when no stick is being pressed
//			if (!fireStick.Pressed() && !moveStick.Pressed())
//			{
//				Aim(0,0);
//			}
		}
	}

//	public void Aim(float angle, float pow)
//	{
//		if ((pow > aimStickDeadZone) && (pow > 0.0001f))
//		{
//			
//			float lockingSpeed = Mathf.Clamp01((pow - aimStickDeadZone) / 
//			                                   (1.0f - aimStickDeadZone));
//
//			orientTarget = Mathf.MoveTowardsAngle(orientTarget,
//			                                           angle, Time.deltaTime * 
//			                                           Mathf.Lerp(aimStickMinSpeed, aimStickMaxSpeed, lockingSpeed));	
//		}
//		
//		// Smooth character's orientation...
//		orientCur = Mathf.SmoothDampAngle(orientCur, 	
//		                                       orientTarget, ref orientVel, turnSmoothingTime  * 0.2f, 
//		                                       maxTurnSpeed);
//
//		transform.localRotation = Quaternion.Euler(0, orientCur, 0);
//	}
//		
//	// ---------------	
//	public void Move(Vector3 worldDir, float speed)
//	{
//		if (Mathf.Clamp01(speed) < 0.001f)
//		{
//			// Stop.
//			worldMoveVec = Vector3.zero;
//		}
//		else
//		{
//			// Transform world vec to local space...
//			Vector3 localDir = RotateVec(worldDir, -orientCur);
//			
//			// Apply Forward/Back/Side speed modifiers...
//			
//			if (localDir.z > 0) 
//				localDir.z *= runForwardSpeed;
//			else
//				localDir.z *= runBackSpeed;
//			
//			localDir.x *= runSideSpeed;
//			
//			// Transform back to world space...
//			
//			worldMoveVec = RotateVec(localDir * speed, orientCur);
//
//			// Move the character...
//			if (charaController != null)
//				charaController.Move(worldMoveVec * Time.deltaTime);
//		}
//	}
//	
//	static private Vector3 RotateVec(Vector3 vec, float angle)
//	{
//		return Quaternion.Euler(0, angle, 0) * vec;
//	}

	#region IMoveComponent implementation

	public void Move(Vector3 worldMoveVec) {
		if (charaController != null)
			charaController.Move(worldMoveVec * Time.deltaTime);
	}
	#endregion

}