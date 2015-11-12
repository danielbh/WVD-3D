using UnityEngine;
using NSubstitute;
using NUnit.Framework;

public class EnemyTests 
{
    GameObject gameObj;

    [TearDown]
    public void TearDown()
    {
        if (gameObj)
        {
            // Hack... without this teardown then GameObject
            // will be instantiated in scene.
            Object.DestroyImmediate(gameObj);
        }
    }

    [Test]
	[Category("Movement")]
	public void EnemyMovesWhenNotAtMinDistance() 
	{
		var moveMock = GetMoveMock();
		var enemyMock = GetEnemyMock(moveMock);

        gameObj = new GameObject();

        gameObj.transform.position = new Vector3(3, 0, 0);

        enemyMock.Move(gameObj.transform, Vector3.zero, 2);

		moveMock.Received(1).Move();
	}

    [Test]
    [Category("Movement")]
    public void LookAtReceivesExpectedArgument()
    {
        var moveMock = GetMoveMock();
        var enemyMock = GetEnemyMock(moveMock);

        gameObj = new GameObject();

        gameObj.transform.position = new Vector3(2, 0, 0);

        enemyMock.Move(gameObj.transform, Vector3.zero, 2);

        moveMock.Received(1).LookAt(gameObj.transform);
    }

    [Test]
	[Category("Combat")]
	public void EnemyAttacksWhenAttackTimerReadyAndPlayerInRange() 
	{
		var attackMock = GetAttackMock();
		var enemyMock = GetEnemyMock(attackMock);

		enemyMock.Attack (3, 2, true, false);

		attackMock.Received(1).MeleeAttack();
	}

	[Test]
	[Category("Combat")]
	public void EnemyDoesNotAttacksWhenAttackTimerNotReadyAndPlayerInRange() 
	{
		var attackMock = GetAttackMock();
		var enemyMock = GetEnemyMock(attackMock);
		
		enemyMock.Attack (1, 2, true, false);
		
		attackMock.DidNotReceive().MeleeAttack();
		attackMock.DidNotReceive().RangedAttack();
	}

	[Test]
	[Category("Combat")]
	public void RangedEnemyAttacksWhenReadyAndPlayerInRange() 
	{
		var attackMock = GetAttackMock();
		var enemyMock = GetEnemyMock(attackMock);
		
		enemyMock.Attack (2, 1, true, true);
		
		attackMock.Received(1).RangedAttack();
	}

	public IMoveComponent GetMoveMock ()
	{
		return Substitute.For<IMoveComponent> ();
	}

	public IAttackComponent GetAttackMock () 
	{
		return Substitute.For<IAttackComponent> ();
	}
	
	public EnemyController GetEnemyMock (IAttackComponent comp) 
	{
		
		var controller = Substitute.For<EnemyController>();
		controller.SetAttackComponent(comp);
		
		return controller;
	}

	public EnemyController GetEnemyMock (IMoveComponent comp) 
	{
		
		var controller = Substitute.For<EnemyController>();
		controller.SetMoveComponent(comp);
		
		return controller;
	}
}
