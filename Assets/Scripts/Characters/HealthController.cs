using UnityEngine;
using System;

[Serializable]
public class HealthController 
{
	public IHealthComponent hpComponent;
	
	public void SetComponent (IHealthComponent component)
	{
		hpComponent = component;
	}
	
	public void ReduceHitPoints (int damage, int currentHP) 
	{
		if (damage >= currentHP) 
		{
			hpComponent.Die();
		} 
		else 
		{
			hpComponent.ReduceHitPoints(damage);
		}
	}
}
