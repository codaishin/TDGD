using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
	public class RotationControlerTests : TestTools.BaseTestClass
	{
		private class RotationLimitMock : RotationLimitHandle
		{
			public float returnCode;

			public float CallAngle { get; private set; }
			public Vector3 CallOffset { get; private set; }
			public Vector3 CallAxis { get; private set; }

			public override
			float Limit(in float angle, in Vector3 offset, in Vector3 axis)
			{
				this.CallAngle = angle;
				this.CallOffset = offset;
				this.CallAxis = axis;
				return this.returnCode;
			}
		}

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


		[Test]
		public void UseLimiterReturnCode()
		{
			var rotCtrl = new GameObject("rotater").AddComponent<RotationControler>();
			var around = new GameObject("around");
			var target = new GameObject("target");
			var limiter = ScriptableObject.CreateInstance<RotationLimitMock>();

			limiter.returnCode = -90;

			target.transform.position = new Vector3(1, 0, 0);

			rotCtrl.around = new GameObjectWrapper(around);
			rotCtrl.target = new GameObjectWrapper(target);
			rotCtrl.limiter = limiter;
			rotCtrl.Rotate(-135);

			TestTools.AssertAreEqual(
				new Vector3(0, 0, 1),
				target.transform.position
			);
		}

		[Test]
		public void PassParamsToLimit()
		{
			var rotCtrl = new GameObject("rotater").AddComponent<RotationControler>();
			var around = new GameObject("around");
			var target = new GameObject("target");
			var limiter = ScriptableObject.CreateInstance<RotationLimitMock>();

			target.transform.position = Vector3.down;
			target.transform.LookAt(Vector3.up);

			rotCtrl.limiter = limiter;
			rotCtrl.around = new GameObjectWrapper(around);
			rotCtrl.target = new GameObjectWrapper(target);
			rotCtrl.Rotate(90);

			Assert.AreEqual(90, limiter.CallAngle);
			TestTools.AssertAreEqual(-Vector3.down, limiter.CallOffset);
			TestTools.AssertAreEqual(Vector3.back, limiter.CallAxis);
		}

		[Test]
		public void PassOffsetFromNonZeroToLimit()
		{
			var rotCtrl = new GameObject("rotater").AddComponent<RotationControler>();
			var around = new GameObject("around");
			var target = new GameObject("target");
			var limiter = ScriptableObject.CreateInstance<RotationLimitMock>();

			around.transform.position = Vector3.up;

			target.transform.position = Vector3.down;
			target.transform.LookAt(Vector3.up);

			rotCtrl.limiter = limiter;
			rotCtrl.around = new GameObjectWrapper(around);
			rotCtrl.target = new GameObjectWrapper(target);
			rotCtrl.Rotate(90);

			TestTools.AssertAreEqual(-Vector3.down * 2, limiter.CallOffset);
		}
	}
}
