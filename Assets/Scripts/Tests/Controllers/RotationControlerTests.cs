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
			var target = new GameObject("target");

			target.transform.position = new Vector3(1, 0, 0);

			rotCtrl.around = new GameObjectWrapper(around);
			rotCtrl.target = new GameObjectWrapper(target);
			rotCtrl.Rotate(-90);

			TestTools.AssertAreEqual(
				new Vector3(0, 0, 1),
				target.transform.position
			);
		}

		[Test]
		public void RotateVertically()
		{
			var rotCtrl = new GameObject("rotater").AddComponent<RotationControler>();
			var around = new GameObject("around");
			var target = new GameObject("target");

			target.transform.position = Vector3.right;

			rotCtrl.axis = Vector3.forward;
			rotCtrl.around = new GameObjectWrapper(around);
			rotCtrl.target = new GameObjectWrapper(target);
			rotCtrl.Rotate(90);

			TestTools.AssertAreEqual(
				Vector3.up,
				target.transform.position
			);
		}

		[Test]
		public void RotateLocal()
		{
			var rotCtrl = new GameObject("rotater").AddComponent<RotationControler>();
			var around = new GameObject("around");
			var target = new GameObject("target");

			target.transform.position = Vector3.down;
			target.transform.LookAt(Vector3.up);

			rotCtrl.around = new GameObjectWrapper(around);
			rotCtrl.target = new GameObjectWrapper(target);
			rotCtrl.Rotate(90);

			TestTools.AssertAreEqual(
				Vector3.left,
				target.transform.position
			);
		}

		[Test]
		public void RotateGlobal()
		{
			var rotCtrl = new GameObject("rotater").AddComponent<RotationControler>();
			var around = new GameObject("around");
			var target = new GameObject("target");

			target.transform.position = Vector3.back;
			target.transform.LookAt(Vector3.up);

			rotCtrl.around = new GameObjectWrapper(around);
			rotCtrl.target = new GameObjectWrapper(target);
			rotCtrl.space = Space.World;
			rotCtrl.Rotate(90);

			TestTools.AssertAreEqual(
				Vector3.left,
				target.transform.position
			);
		}
	}
}
