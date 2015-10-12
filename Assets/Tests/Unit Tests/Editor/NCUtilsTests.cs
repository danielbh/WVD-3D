using UnityEngine;
using System.Collections;
using NUnit.Framework;


public class NCUtilsTests {

	[Test]
	[Category("MaxRangeTravelled")]
	public void IfMaxRangeTravelledReturnTrue() 
	{	
		bool result = NCUtils.CheckIfMaxRangeTravelled(10, Vector3.zero, new Vector3(10, 0, 0));
		Assert.True(result);
	}

	[Test]
	[Category("MaxRangeTravelled")]
	public void IfMaxRangeNotTravelledReturnFalse() 
	{	
		bool result = NCUtils.CheckIfMaxRangeTravelled(11, Vector3.zero, new Vector3(10, 0, 0));
		Assert.False(result);
	}
}
