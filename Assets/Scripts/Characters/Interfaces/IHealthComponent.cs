using UnityEngine;
using System.Collections;

public interface IHealthComponent
{
	void ReduceHitPoints(int damage);
	void Die();
}
