using UnityEngine;
using NSubstitute;
using NUnit.Framework;
using System;

[TestFixture]
public class HealthTests  {
	
	private IHealthComponent component;
	private HealthController controller;
	
	[SetUp] public void Init() 
	{ 
		component = GetHealthMock();
		controller = GetControllerMockForHealth(component);
	}
	
	[Test]
	[Category("Hitpoints")]
	public void LoseHitPoints() 
	{
		controller.ReduceHitPoints (25, 100);
		component.Received(1).ReduceHitPoints(25);
	}
	
	[Test]
	[Category("Hitpoints")]
	public void EnemyMeleeDiesOnZeroHitPoints()
	{
		controller.ReduceHitPoints (25,25);
		
		component.DidNotReceive().ReduceHitPoints(25);
		component.Received(1).Die();
	}
	
	public IHealthComponent GetHealthMock () 
	{
		return Substitute.For<IHealthComponent> ();
	}
	
	public HealthController GetControllerMockForHealth (IHealthComponent component) 
	{
		var controller = Substitute.For<HealthController>();
		controller.SetComponent(component);
		return controller;
	}
}