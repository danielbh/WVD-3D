using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Animator))]
public class EnemyAttack : MonoBehaviour, IAttackComponent {

	[HideInInspector]
	public EnemyController controller;
	public bool ranged;
	public int damage = 25;

	// Only valid if ranged is true
	public Projectile projectile;
	public GameObject weapon;

	public float timeBetweenAttacks = 1.5f;
//	public int attackDamage = 10;

	Animator anim;
	GameObject player;
	bool playerInRange;
	float timer;

	void Awake ()
	{
		controller.SetAttackComponent(this);
     
		// Setting up the references
		player = GameObject.FindGameObjectWithTag ("Player");
		anim = GetComponent <Animator> ();

		if (ranged == false && projectile != null) 
		{
			Debug.LogError("You have given a melee character a projectile, Make the character ranged or remove the projectile");
		}
	}

	void OnTriggerEnter (Collider other)
	{
		// If the entering collider is the player...
		if(other.gameObject == player)
		{
			// ... the player is in range.
			playerInRange = true;
		}
	}

	void OnTriggerExit (Collider other)
	{
		// If the exiting collider is the player...
		if(other.gameObject == player)
		{
			// ... the player is no longer in range.
			playerInRange = false;
		}
	}
	
	void Update ()
	{
		// Add the time since Update was last called to the timer.
		timer += Time.deltaTime;

		// If player is alive, and attack is enabled
		if (player != null)
        {
			// If the timer exceeds the time between attacks, the player is in range and this enemy is alive...
			controller.Attack(timer, timeBetweenAttacks, playerInRange, ranged);
		}
	}

	public void Attack ()
	{
		timer = 0;
		anim.SetTrigger ("Attack");
	}
	
	#region IAttackComponent implementation

	public void MeleeAttack() {
		Attack();
		player.GetComponent<NCHealth>().Hit(damage);
	}

	public void RangedAttack() {
		Attack();
		Projectile proj = Instantiate(projectile, weapon.transform.position, Quaternion.identity) as Projectile; 
		Vector3 vectorToPlayer = player.transform.position - weapon.transform.position;
		// So it doesn't go underground. The player position y might be on a different y value then projectile launch point.
		vectorToPlayer.y = 0;
		vectorToPlayer.Normalize();
		proj.Shoot(vectorToPlayer);
	}

	#endregion


}
