using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
	public class RotationControlerTests : TestTools.BaseTestClass
	{
		[Test]
		public void Rotate()
		{
			var rotCtrl = new GameObject("rotater").AddComponent<RotationControler>();
			var around = new GameObject("around");

			rotCtrl.transform.position = new Vector3(1, 0, 0);
			rotCtrl.around = new GameObjectWrapper(around);
			rotCtrl.Rotate(-90);

			TestTools.AssertAreEqual(
				new Vector3(0, 0, 1),
				rotCtrl.transform.position
			);
		}
	}
}
