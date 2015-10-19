using UnityEngine;
using System.Collections.Generic;
using System.Collections;

[RequireComponent (typeof (Animator))]
[RequireComponent (typeof (PlayerMagic))]
public class Player : MonoBehaviour {
	
	const int STICK_MOVE	= 0;
	const int STICK_FIRE	= 1;

	const string CONCUSSIVE_BLAST = "CONCUSSIVE_BLAST_SPELL";
	const string WIZARD_SHIELD = "WIZARD_SHIELD_SPELL";
	const string TELEPORT = "TELEPORT_SPELL";
	const string ICE_NOVA = "ICE_NOVA_SPELL";
	const string METEOR_SHOWER = "METEOR_SHOWER_SPELL";
	
	public float	aimStickDeadZone	= 0.2f;
	public float	aimStickMinSpeed	= 0;		// aim locking speed just above dead zone (degs/sec) 
	public float	aimStickMaxSpeed	= 500;	// aim locking speed at maximum stick tilt (degs/sec)
	
	public	float	maxTurnSpeed		= 500;	// max turn smoothing speed 
	public	float	turnSmoothingTime	= 0.3f;		// turn smoothing time
	
	public float timeBetweenAttacks= 0.5f;
	
	[HideInInspector]
	public ActionController actionController; // Test wrapper neccesary for making code testable
	public TouchController	touchController; // Input controller for player actions (ex: move, fire, etc...)
	
	public float	runForwardSpeed		= 6,		// max speed when running forward
	runBackSpeed		= 3,		// max speed when running back
	runSideSpeed		= 4;	// max speed when running to the side
	
	Animator animator;
	
	TouchStick fireStick;
	TouchStick moveStick;
	
	List<TouchZone> SpellButtons
	{
		get 
		{
			List<TouchZone> results = new List<TouchZone>();
			foreach (TouchZone tz in touchController.touchZones) {
				if (tz.name.Contains ("SPELL")) // TODO: Too prone to failure!!!
				{
					results.Add(tz);
				}
			}
			return results;
		}
	}
	
	float attackTimer;
	PlayerMagic magic;
	
	public void Awake()
	{
		animator = GetComponent<Animator>();
		magic = GetComponent<PlayerMagic>();
		moveStick	= touchController.GetStick(STICK_MOVE);
		fireStick	= touchController.GetStick(STICK_FIRE);
	}
	
	public void Update() 
	{
		attackTimer += Time.deltaTime;
		
		if (touchController != null)
		{
			ManageMoveStick();
			ManageFireStick();
			ManageSpellButtons();
		}
	}
	
	void ManageMoveStick() {
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
	}
	
	void ManageFireStick() {
		if (fireStick.Pressed())
		{
			transform.localRotation = LookRotation(fireStick.GetVec3d(true, 0));
			
			if (attackTimer >= timeBetweenAttacks && Time.timeScale != 0)
			{
				Attack();
			}
		}
	}
	
	void ManageSpellButtons() {
		foreach (TouchZone sb in SpellButtons) {
			if (sb.JustUniPressed()) {
				Debug.Log (sb.name + " HAS BEEN CAST");
				switch ( sb.name) 
				{
				case CONCUSSIVE_BLAST :
					magic.CastConcussiveBlastSpell(); 
					break;
				case WIZARD_SHIELD :
					magic.CastWizardShieldSpell();
					break;
				case TELEPORT:
					magic.CastTeleportSpell();
					break;
				case ICE_NOVA:
					magic.CastIceNovaSpell();
					break;
				case METEOR_SHOWER:
					magic.CastMeteorShowerSpell();
					break;
				default:
					break;
				}
			}
		}
	}
	
	public void Attack() {
		
		attackTimer = 0;
		
		Vector3 aimVec = fireStick.GetAngle() == 0 ? transform.localRotation * Vector3.forward : fireStick.GetVec3d(true, 0);
		
		magic.CastPrimarySpell(aimVec);
	}
	
	Quaternion LookRotation(Vector3 dir) 
	{
		if (dir != Vector3.zero)
			return Quaternion.LookRotation(dir);
		
		return Quaternion.identity;
	}
}