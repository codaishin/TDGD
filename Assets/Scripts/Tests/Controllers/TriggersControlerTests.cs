using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
	public class TriggersControlerTests : TestTools.BaseTestClass
	{
		[Test]
		public void Empty()
		{
			var triggersCtrl = new GameObject("obj")
				.AddComponent<TriggersControler>();

			Assert.IsEmpty(triggersCtrl);
		}

		[UnityTest]
		public IEnumerator Trigger()
		{
			var other = new GameObject("other");
			var triggersCtrl = new GameObject().AddComponent<TriggersControler>();
			other.AddComponent<Rigidbody>().useGravity = false;
			other.AddComponent<SphereCollider>();
			triggersCtrl.gameObject.AddComponent<SphereCollider>().isTrigger = true;

			yield return new WaitForEndOfFrame(); // Start()
			yield return new WaitForEndOfFrame(); // Update()

			CollectionAssert.AreEqual(
				new Collider[] { other.GetComponent<Collider>() },
				triggersCtrl
			);
		}

		[UnityTest]
		public IEnumerator TriggerLeave()
		{
			var other = new GameObject("other");
			var triggersCtrl = new GameObject().AddComponent<TriggersControler>();
			other.AddComponent<Rigidbody>().useGravity = false;
			other.AddComponent<SphereCollider>();
			triggersCtrl.gameObject.AddComponent<SphereCollider>().isTrigger = true;

			yield return new WaitForEndOfFrame(); // Start()
			yield return new WaitForEndOfFrame(); // Update()

			other.transform.position = new Vector3(10, 0, 0);

			yield return new WaitForEndOfFrame();

			Assert.IsEmpty(triggersCtrl);
		}
	}
}
