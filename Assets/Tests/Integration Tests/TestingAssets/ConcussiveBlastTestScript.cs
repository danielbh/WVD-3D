using UnityEngine;
using System.Collections;
using System;

public class ConcussiveBlastTestScript : NCMonoBehaviour 
{

	GameObject player;
	public float castInterval = 0.5f;
	public int timesCast = 3;

	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
		StartCoroutine(InvokeMethod(Cast, castInterval, timesCast));
	}

	void Cast()
	{
		player.gameObject.GetComponent<PlayerMagic>().CastConcussiveBlastSpell();
	}
}
