using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour, IMoveComponent {
	
	public const int STICK_MOVE	= 0;
	public const int STICK_FIRE	= 1;
	
	public	float	aimStickDeadZone	= 0.2f;
	public	float	aimStickMinSpeed	= 0;		// aim locking speed just above dead zone (degs/sec) 
	public  float	aimStickMaxSpeed	= 500;	// aim locking speed at maximum stick tilt (degs/sec)
	
	public	float	maxTurnSpeed		= 500;	// max turn smoothing speed 
	public	float	turnSmoothingTime	= 0.3f;		// turn smoothing time
	
	[HideInInspector]
	public PlayerController playerController; // Test wrapper neccesary for making code testable
	public TouchController	touchController; // Input controller for player actions (ex: move, fire, etc...)
	
	public float	runForwardSpeed		= 6,		// max speed when running forward
	runBackSpeed		= 3,		// max speed when running back
	runSideSpeed		= 4;	// max speed when running to the side
	
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
				playerController.Move(moveStick.GetVec3d(true, 0), moveStick.GetTilt(), runForwardSpeed, 
				                      runBackSpeed, runSideSpeed);

				if (!fireStick.Pressed()) 
				{
					playerController.FaceDir(moveStick.GetAngle(), moveStick.GetTilt(), aimStickDeadZone, aimStickMinSpeed,
					                         aimStickMaxSpeed, maxTurnSpeed, turnSmoothingTime);
				}
			}

			if (fireStick.Pressed())
			{
				// Get target angle and stick's tilt to determinate turning speed.
				playerController.FaceDir(fireStick.GetAngle(), fireStick.GetTilt(), aimStickDeadZone, aimStickMinSpeed, 
				                         aimStickMaxSpeed, maxTurnSpeed, turnSmoothingTime);
			}
		}
	}

	#region IMoveComponent implementation

	public void FaceDir(Quaternion rotation) {
		transform.localRotation = rotation;
	}

	public void Move(Vector3 worldMoveVec) 
	{
		if (charaController != null)
			charaController.Move(worldMoveVec * Time.deltaTime);
	}

	#endregion

}