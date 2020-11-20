using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
	public class CameraControlerTests : TestTools.BaseTestClass
	{
		[UnityTest]
		public IEnumerator OffsetVector()
		{
			var camCtrl = new GameObject("camera").AddComponent<CameraControler>();
			var target = new GameObject("target");
			camCtrl.target = new GameObjectWrapper(target, null);

			yield return new WaitForEndOfFrame();

			camCtrl.offsetVector = new Vector3(1, 2, 3);

			yield return new WaitForEndOfFrame();

			TestTools.AssertAreEqual(
				new Vector3(1, 2, 3),
				camCtrl.transform.position - target.transform.position
			);
		}

		[UnityTest]
		public IEnumerator FaceTarget()
		{
			var camCtrl = new GameObject("camera").AddComponent<CameraControler>();
			var target = new GameObject("target");
			camCtrl.target = new GameObjectWrapper(target, null);

			yield return new WaitForEndOfFrame();

			camCtrl.offsetVector = new Vector3(1, 2, 3);

			yield return new WaitForEndOfFrame();

			var expected = Quaternion.LookRotation(
				target.transform.position - camCtrl.transform.position
			);
			var actual = camCtrl.transform.rotation;

			TestTools.AssertAreEqual(expected.eulerAngles, actual.eulerAngles);
		}
	}
}
