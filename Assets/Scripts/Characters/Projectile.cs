using UnityEngine;
using System.Collections;

[RequireComponent (typeof (BoxCollider))]
public class Projectile : MonoBehaviour {

	public int damage = 25;
	public float speed = 8;
	public float range = 10;

	Vector3 origin;

	void Start() {
		origin = transform.position;
	}

	void Update() {
		if (NCUtils.CheckIfMaxRangeTravelled(range, origin, transform.position)) {
			Destroy(gameObject);
		}
	}

	void OnCollisionEnter(Collision col)
	{
		NCHealth hpComponent = col.gameObject.GetComponent<NCHealth>();

		if (hpComponent != null) 
		{
			hpComponent.Hit(damage);
		}

		Destroy (this.gameObject);
	}

	public void Shoot(Vector3 dir) { 
		GetComponent<Rigidbody>().velocity = new Vector3(dir.x * speed , dir.y * speed,  speed * dir.z); 
	}
}