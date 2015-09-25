using UnityEngine;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;

[TestFixture]
public class PlayerTests
{
	
	[Test]
	[Category("Movement")]
	public void IMoveComponentMoveCalledWithExpectedArgument() 
	{	
		var moveMock = GetMoveMock();
		var playerController = GetPlayerControllerMock(moveMock);
		
		playerController.Move(Vector3.right, 1, 6, 3, 4);
		
		moveMock.Received(1).Move(new Vector3(4,0,0));
	}

	[Test]
	[Category("Movement")]
	public void IMoveComponentMoveCalledWithVectorZeroForNoMovementInput() 
	{ 
		var moveMock = GetMoveMock();
		var playerController = GetPlayerControllerMock(moveMock);
		
		playerController.Move(Vector3.zero, 0, 6, 3, 4);
		
		moveMock.Received(1).Move(Vector3.zero);
	}

	[Test]
	[Category("Movement")]
	public void  FaceDirectionInputOutputsExpected() {
		var moveMock = GetMoveMock();
		var playerController = GetPlayerControllerMock(moveMock);

		playerController.FaceDir(125, 1, 0.2f, 0, 500, 500, 0.3f);

		moveMock.Received(1).FaceDir(new Quaternion(0.0f,0.0f,0.0f, 1f));
	}
	
	private IMoveComponent GetMoveMock () 
	{
		return Substitute.For<IMoveComponent> ();
	}
	
	private PlayerController GetPlayerControllerMock (IMoveComponent move) 
	{
		
		var playerController = Substitute.For<PlayerController>();
		playerController.SetMoveComponent(move);
		return playerController;
	}
}
