using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
	public class RotationLimitHandleTests : TestTools.BaseTestClass
	{
		[Test]
		public void Limit()
		{
			var limitHandle = ScriptableObject
				.CreateInstance<RotationStaticLimitHandle>();

			limitHandle.levelPlaneNormal = Vector3.up;
			limitHandle.max = 30;

			var rotation = limitHandle.Limit(45, Vector3.forward, Vector3.right);

			Assert.AreEqual(30, rotation);
		}

		[Test]
		public void DontLimit()
		{
			var limitHandle = ScriptableObject
				.CreateInstance<RotationStaticLimitHandle>();

			limitHandle.levelPlaneNormal = Vector3.up;
			limitHandle.max = 60;

			var rotation = limitHandle.Limit(45, Vector3.forward, Vector3.right);

			Assert.AreEqual(45, rotation);
		}

		[Test]
		public void LimitFromAngle()
		{
			var limitHandle = ScriptableObject
				.CreateInstance<RotationStaticLimitHandle>();

			limitHandle.levelPlaneNormal = Vector3.up;
			limitHandle.max = 60;

			var rotation = limitHandle.Limit(
				20,
				new Vector3(0, 1, 1), // => offset of 45°
				Vector3.right
			); // => aiming for 65°

			Assert.AreEqual(15, rotation);
		}

		[Test]
		public void LimitMin()
		{
			var limitHandle = ScriptableObject
				.CreateInstance<RotationStaticLimitHandle>();

			limitHandle.levelPlaneNormal = Vector3.up;
			limitHandle.max = 60;
			limitHandle.min = 20;

			var rotation = limitHandle.Limit(
				-30,
				new Vector3(0, 1, 1), // => offset of 45°
				Vector3.right
			); // => aiming for 15°

			Assert.AreEqual(-25, rotation);
		}
	}
}
