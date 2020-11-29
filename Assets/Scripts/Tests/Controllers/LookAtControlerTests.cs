using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
	public class LookAtControlerTests : TestTools.BaseTestClass
	{
		[Test]
		public void LookAt()
		{
			var target = new GameObject("target");
			var lookAt = new GameObject("lookAt");
			var lookCtrl = new GameObject("look").AddComponent<LookAtControler>();

			lookAt.transform.position = Vector3.up;

			lookCtrl.target = new GameObjectWrapper(target);
			lookCtrl.lookAt = new GameObjectWrapper(lookAt);

			lookCtrl.Apply();

			var expected = Quaternion.LookRotation(Vector3.up);

			TestTools.AssertAreEqual(
				expected.eulerAngles,
				target.transform.rotation.eulerAngles
			);
		}

		[Test]
		public void LookAtInvert()
		{
			var target = new GameObject("target");
			var lookAt = new GameObject("lookAt");
			var lookCtrl = new GameObject("look").AddComponent<LookAtControler>();

			lookAt.transform.position = Vector3.up;

			lookCtrl.target = new GameObjectWrapper(target);
			lookCtrl.lookAt = new GameObjectWrapper(lookAt);
			lookCtrl.invert = true;

			lookCtrl.Apply();

			var expected = Quaternion.LookRotation(-Vector3.up);

			TestTools.AssertAreEqual(
				expected.eulerAngles,
				target.transform.rotation.eulerAngles
			);
		}

		[Test]
		public void LookAtInvertFromNonOrigin()
		{
			var target = new GameObject("target");
			var lookAt = new GameObject("lookAt");
			var lookCtrl = new GameObject("look").AddComponent<LookAtControler>();

			target.transform.position = Vector3.up * 2;
			lookAt.transform.position = Vector3.up;

			lookCtrl.target = new GameObjectWrapper(target);
			lookCtrl.lookAt = new GameObjectWrapper(lookAt);
			lookCtrl.invert = true;

			lookCtrl.Apply();

			var expected = Quaternion.LookRotation(Vector3.up);

			TestTools.AssertAreEqual(
				expected.eulerAngles,
				target.transform.rotation.eulerAngles
			);
		}
	}
}
