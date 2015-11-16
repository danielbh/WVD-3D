using UnityEngine;
using System.Collections;

public class WizardShield : MonoBehaviour 
{
    public float duration = 5;
    public float timer;

    GameObject player;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag ("Player");

		if (player != null)
		{
			player.GetComponent<NCHealth>().invulnerable = true;
		}
		else
		{
			Debug.LogError ("Player doesn't exist.");
		}
	}

	void Update() 
	{
        timer += Time.deltaTime;
        //Debug.Log(timer);

        if (player != null && timer < duration) 
		{
			// FIXME: Raises up spell effect so it's not below ground. Figure out how to make this so it's not neccesary
			transform.position = new Vector3(player.transform.position.x, 1.25f, player.transform.position.z);
		} 
		else
		{
			Destroy (gameObject);
		}
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.layer == LayerMask.NameToLayer("Enemy Projectile"))
		{
			GameObject proj = col.gameObject;
			Reflect(proj);
			// TODO: Reflect the projectile at the inverse vector back to source
			// TODO: Modify projectile?
		}
	}

	void Reflect(GameObject proj)
	{
		// Get the current velocity of the projectile to be reversed later.
		Vector3 vel = proj.GetComponent<Rigidbody>().velocity;

		// Reverse the direction of the projectile so it's facing it's source
		Quaternion newRot = proj.gameObject.transform.localRotation * Quaternion.AngleAxis(180, Vector3.up);

		// Change the projectile to only hit enemies.
		proj.gameObject.layer = LayerMask.NameToLayer("Player Projectile");

		// Instantiate a copy of the projectile, as the original will be destroyed by the collision.
		GameObject reflectedProj = Instantiate(proj, transform.position, newRot) as GameObject;

		// Get the projectile script component to manipulate values.
		Projectile projComp = reflectedProj.GetComponent<Projectile>();

		//  Get the speed of projectile so the reflected projectile moves at the same speed.
		float speed = projComp.speed;

		// Shoot projectile at same speed and normalized so that it moves at the same velocity.
		projComp.Shoot(new Vector3(-vel.x * speed , 0, -vel.z * speed).normalized);
	}

	void OnDestroy() {
		if (player != null)
		{
			player.GetComponent<NCHealth>().invulnerable = false;
		}
	}
}
