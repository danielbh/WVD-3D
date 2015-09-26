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
		var actionController = GetActionControllerMock();
		
		var expected = new Vector3(4,0,0);
		var actual = actionController.Move(Vector3.right, 1, 6, 3, 4);
		
		Assert.AreEqual(expected, actual);
	}
	
	[Test]
	[Category("Movement")]
	public void IMoveComponentMoveCalledWithVectorZeroForNoMovementInput() 
	{ 
		var actionController = GetActionControllerMock();
		
		var expected = Vector3.zero;
		var actual = actionController.Move(Vector3.zero, 0, 6, 3, 4);
		
		Assert.AreEqual (expected, actual);
	}

	private ActionController GetActionControllerMock () 
	{
		var actionController = Substitute.For<ActionController>();
		return actionController;
	}
}
