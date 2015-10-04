using UnityEngine;
using System.Collections;
using NSubstitute;
using NUnit.Framework;

public class EnemyTests : MonoBehaviour 
{

	[Test]
	[Category("Movement")]
	public void EnemyMovesWhenNotAtMinDistance() 
	{

		var moveMock = GetMoveMock();
		var enemyMock = GetEnemyMock(moveMock);

		enemyMock.Move(new Vector3(3, 0, 0), Vector3.zero, 2);

		moveMock.Received(1).Move();
	}

	[Test]
	[Category("Movement")]
	public void EnemyStopsWhenAtMinDistance() 
	{
		
		var moveMock = GetMoveMock();
		var enemyMock = GetEnemyMock(moveMock);
		
		enemyMock.Move(new Vector3(2, 0, 0), Vector3.zero, 2);
		
		moveMock.Received(1).Stop();
	}

	[Test]
	[Category("Combat")]
	public void EnemyAttacksWhenAttackTimerReadyAndPlayerInRange() 
	{
		var attackMock = GetAttackMock();
		var enemyMock = GetEnemyMock(attackMock);

		enemyMock.Attack (3, 2, true);

		attackMock.Received(1).Attack();
	}

	[Test]
	[Category("Combat")]
	public void EnemyDoesNotAttacksWhenAttackTimerNotReadyAndPlayerInRange() 
	{
		var attackMock = GetAttackMock();
		var enemyMock = GetEnemyMock(attackMock);
		
		enemyMock.Attack (1, 2, true);
		
		attackMock.DidNotReceive().Attack();
	}

	public IMoveComponent GetMoveMock ()
	{
		return Substitute.For<IMoveComponent> ();
	}

	public IAttackComponent GetAttackMock () 
	{
		return Substitute.For<IAttackComponent> ();
	}
	
	public EnemyActionController GetEnemyMock (IAttackComponent comp) 
	{
		
		var controller = Substitute.For<EnemyActionController>();
		controller.SetAttackComponent(comp);
		
		return controller;
	}

	public EnemyActionController GetEnemyMock (IMoveComponent comp) 
	{
		
		var controller = Substitute.For<EnemyActionController>();
		controller.SetMoveComponent(comp);
		
		return controller;
	}
}
