using UnityEngine;
using System.Collections;
using NSubstitute;
using NUnit.Framework;

public class EnemyTests : MonoBehaviour {

	[Test]
	[Category("Movement")]
	public void EnemyMovesWhenNotAtMinDistance() {

		var moveMock = GetMoveMock();
		var enemyMock = GetEnemyMock(moveMock);

		enemyMock.Move(new Vector3(3, 0, 0), Vector3.zero);

		moveMock.Received(1).Move();
	}

	[Test]
	[Category("Movement")]
	public void EnemyStopsWhenAtMinDistance() {
		
		var moveMock = GetMoveMock();
		var enemyMock = GetEnemyMock(moveMock);
		
		enemyMock.Move(new Vector3(2, 0, 0), Vector3.zero);
		
		moveMock.Received(1).Stop();
	}

	public IMoveComponent GetMoveMock () {
		return Substitute.For<IMoveComponent> ();
	}

	public EnemyActionController GetEnemyMock (IMoveComponent move) {
		
		var controller = Substitute.For<EnemyActionController>();
		controller.SetMoveComponent(move);
		
		return controller;
	}
}
