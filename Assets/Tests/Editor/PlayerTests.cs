using UnityEngine;
using NSubstitute;
using NUnit.Framework;
using System;

[TestFixture]
public class PlayerTests
{
	
	[Test]
	[Category("Movement")]
	public void IMoveComponentCalledWithExpectedArgument() {

		var moveMock = GetMoveMock();
		var playerController = GetPlayerControllerMock(moveMock);

		playerController.Move(Vector3.right, 1);
		
		moveMock.Received(1).Move(Vector3.right);
	}

	// TODO: Player faces correct initial direction
	// TODO: 

	private IMoveComponent GetMoveMock () {
		return Substitute.For<IMoveComponent> ();
	}
	
	private PlayerController GetPlayerControllerMock (IMoveComponent move) {
		
		var playerController = Substitute.For<PlayerController>();
		playerController.SetMoveComponent(move);
		
		return playerController;
	}
}



