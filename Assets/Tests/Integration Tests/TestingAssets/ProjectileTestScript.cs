using UnityEngine;
using System.Collections;
using System;

public class ProjectileTestScript : MonoBehaviour {

	public Vector3 vector;
	public Projectile projectile;

	// Use this for initialization
	void Start () {
		projectile.Shoot(vector);
	}

}
