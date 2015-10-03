using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	
	public int damage = 25;
	public float speed = 8;
	
	public void Shoot(Vector3 dir) { 
		GetComponent<Rigidbody>().velocity = new Vector3(dir.x * speed , dir.y * speed,  speed * dir.z); 
	}
}