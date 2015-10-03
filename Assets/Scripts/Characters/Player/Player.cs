using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Player : MonoBehaviour {
	
	public const int STICK_MOVE	= 0;
	public const int STICK_FIRE	= 1;
	
	public	float	aimStickDeadZone	= 0.2f;
	public	float	aimStickMinSpeed	= 0;		// aim locking speed just above dead zone (degs/sec) 
	public  float	aimStickMaxSpeed	= 500;	// aim locking speed at maximum stick tilt (degs/sec)
	
	public	float	maxTurnSpeed		= 500;	// max turn smoothing speed 
	public	float	turnSmoothingTime	= 0.3f;		// turn smoothing time
	
	public GameObject staffEnd;
	
	public float attackTimer;
	public float timeBetweenAttacks= 0.5f;
	
	[HideInInspector]
	public ActionController actionController; // Test wrapper neccesary for making code testable
	public TouchController	touchController; // Input controller for player actions (ex: move, fire, etc...)
	
	public Projectile primarySpell;
	
	public float	runForwardSpeed		= 6,		// max speed when running forward
	runBackSpeed		= 3,		// max speed when running back
	runSideSpeed		= 4;	// max speed when running to the side
	
	private  Animator animator;
	private CharacterController	charaController;	
	
	private TouchStick fireStick;
	private TouchStick moveStick;
	
	public void OnEnable()
	{
		charaController = gameObject.GetComponent<CharacterController>();
		animator = gameObject.GetComponent<Animator>();
		
		moveStick	= touchController.GetStick(STICK_MOVE);
		fireStick	= touchController.GetStick(STICK_FIRE);
	}
	
	public void Update() 
	{
		attackTimer += Time.deltaTime;
		
		if (touchController != null)
		{
			if (moveStick.Pressed())
			{	
				animator.SetBool("Moving", true);
				animator.SetBool("Running", true);
				
				// Use stick's normalized XZ vector and tilt to move...
				var worldMoveVec = actionController.Move(moveStick.GetVec3d(true,0), moveStick.GetTilt(), runForwardSpeed, 
				                                         runBackSpeed, runSideSpeed);
				
				transform.position += worldMoveVec * Time.deltaTime;
				
				if (!fireStick.Pressed()) 
				{
					transform.localRotation = LookRotation(moveStick.GetVec3d(true, 0));
				}
			} 
			
			if (!moveStick.Pressed())
			{
				animator.SetBool("Moving", false);
				animator.SetBool("Running", false);
			}
			
			if (fireStick.Pressed())
			{
				transform.localRotation = LookRotation(fireStick.GetVec3d(true, 0));
				
				if (attackTimer >= timeBetweenAttacks && Time.timeScale != 0)
				{
					Attack();
				}
			}
			
		}
	}
	
	public void Attack() {
		
		attackTimer = 0;
		
		Vector3 aimVec = fireStick.GetAngle() == 0 ? transform.localRotation * Vector3.forward : fireStick.GetVec3d(true, 0);
		
		Projectile spell = Instantiate(primarySpell, staffEnd.transform.position, Quaternion.identity) as Projectile; 
		
		spell.Shoot(aimVec);
	}
	
	private Quaternion LookRotation(Vector3 dir) 
	{
		if (dir != Vector3.zero)
			return Quaternion.LookRotation(dir);
		
		return Quaternion.identity;
	}
}