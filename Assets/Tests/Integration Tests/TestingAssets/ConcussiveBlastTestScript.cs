using UnityEngine;
using System.Collections;
using System;

public class ConcussiveBlastTestScript : NCMonoBehaviour 
{
	GameObject player;
    GameObject enemy; 
	public float castInterval = 0.5f;
    public float delayToCast = 0.5f;
	public int timesCast = 3;

	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");

        enemy = GameObject.FindGameObjectWithTag("Enemy");

        if (delayToCast != 0)
        {
            Invoke("StartCastCoroutine", delayToCast);
        }
        else
        {
            StartCastCoroutine();
        }
	}

    void Update()
    {
        if (enemy != null)
        {
            player.transform.position = enemy.transform.position;
        }
    }
    void StartCastCoroutine()
    {
        StartCoroutine(InvokeMethod(Cast, castInterval, timesCast));
    }

    void Cast()
	{
		player.gameObject.GetComponent<PlayerMagic>().CastConcussiveBlastSpell();
	}
}
