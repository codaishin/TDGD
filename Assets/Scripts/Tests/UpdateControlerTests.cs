using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
	public class UpdateControlerTests : TestTools.BaseTestClass
	{
		[UnityTest]
		public IEnumerator OnUpdateInitialized()
		{
			var updateCtrl = new GameObject("update").AddComponent<UpdateControler>();

			yield return new WaitForEndOfFrame();  // Start()

			Assert.NotNull(updateCtrl.onUpdate);
		}

		[UnityTest]
		public IEnumerator OnFixedUpdateInitialized()
		{
			var updateCtrl = new GameObject("update").AddComponent<UpdateControler>();

			yield return new WaitForEndOfFrame();  // Start()

			Assert.NotNull(updateCtrl.onFixedUpdate);
		}

		[UnityTest]
		public IEnumerator CallOnUpdate()
		{
			var called = 0;
			var updateCtrl = new GameObject("update").AddComponent<UpdateControler>();

			yield return new WaitForEndOfFrame();  // Start()

			updateCtrl.onUpdate.AddListener(() => ++called);

			yield return new WaitForEndOfFrame();  // Update()

			Assert.AreEqual(1, called);
		}

		[UnityTest]
		public IEnumerator CallOnFixedUpdate()
		{
			var called = 0;
			var updateCtrl = new GameObject("update").AddComponent<UpdateControler>();

			yield return new WaitForEndOfFrame();  // Start()

			updateCtrl.onFixedUpdate.AddListener(() => ++called);

			yield return new WaitForFixedUpdate();  // FixedUpdate()

			Assert.AreEqual(1, called);
		}
	}
}
