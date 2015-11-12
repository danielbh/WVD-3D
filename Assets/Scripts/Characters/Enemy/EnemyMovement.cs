using UnityEngine;
using System.Collections;
using System;

[RequireComponent (typeof (NavMeshAgent))]
[RequireComponent (typeof (SphereCollider))]
[RequireComponent (typeof (Animator))]
public class EnemyMovement : MonoBehaviour, IMoveComponent
{
	[HideInInspector]
	public EnemyController controller;

    public bool immobilized = false; // Enemy will not move on true.
		 
	float stopDistFromPlayer;

	GameObject player;
	NavMeshAgent nav;               // Reference to the nav mesh agent.

	private  Animator animator;

	void Awake ()
	{
		controller.SetMoveComponent (this);
		// Set up the references.
		player = GameObject.FindGameObjectWithTag ("Player");
		animator = gameObject.GetComponent<Animator>();
		nav = GetComponent <NavMeshAgent> ();

		 stopDistFromPlayer = GetComponent <SphereCollider>().radius;
	}
	
	void Update ()
	{
		// If player is alive.
		if (player != null && immobilized == false) {
            // TODO: re-enable animation in case of previous immobilized.
            controller.Move(player.transform, transform.position, stopDistFromPlayer);
        } else {
            // If player is dead enemies will not run to the last player location recieved.
			Stop();
		}
	}

	#region IMoveComponent implementation

	public void Move () {
		nav.enabled = true;
		// TODO: Change when real animations are implemented
		animator.SetBool("Walk" , true);
		nav.SetDestination (player.transform.position);
	}

	public void Stop () {
		// ... disable the nav mesh agent.
		nav.enabled = false;
		// TODO: Change when real animations are implemented
		animator.SetBool("Walk", false);
	}

    public void LookAt(Transform target)
    {
        transform.LookAt(player.transform);
    }

    #endregion
}
