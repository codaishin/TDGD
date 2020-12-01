using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
	public class JumpControlerTests : TestTools.BaseTestClass
	{
		private class TriggersMock : MonoBehaviour, IEnumerable<Collider>
		{
			public List<Collider> colliders = new List<Collider>();

			public IEnumerator<Collider> GetEnumerator()
				=> this.colliders.GetEnumerator();

			IEnumerator IEnumerable.GetEnumerator()
				=> this.GetEnumerator();
		}

		[UnityTest]
		public IEnumerator Jump()
		{
			var targetRb = new GameObject("target").AddComponent<Rigidbody>();
			var jumpCtrl = new GameObject("jump").AddComponent<JumpControler>();
			var triggerMock = new GameObject("triggers").AddComponent<TriggersMock>();

			jumpCtrl.targetRigidbody = new GameObjectWrapper(targetRb.gameObject);
			jumpCtrl.targetTriggers = new GameObjectWrapper(triggerMock.gameObject);
			targetRb.useGravity = false;

			yield return new WaitForEndOfFrame(); // Start

			triggerMock.colliders
				.Add(new GameObject("collider").AddComponent<SphereCollider>());

			jumpCtrl.Jump();

			TestTools.AssertAreEqual(Vector3.up, targetRb.velocity);
		}

		[UnityTest]
		public IEnumerator NoJumpWhenNotTriggered()
		{
			var targetRb = new GameObject("target").AddComponent<Rigidbody>();
			var jumpCtrl = new GameObject("jump").AddComponent<JumpControler>();
			var triggerMock = new GameObject("triggers").AddComponent<TriggersMock>();

			jumpCtrl.targetRigidbody = new GameObjectWrapper(targetRb.gameObject);
			jumpCtrl.targetTriggers = new GameObjectWrapper(triggerMock.gameObject);
			targetRb.useGravity = false;

			yield return new WaitForEndOfFrame(); // Start

			jumpCtrl.Jump();

			TestTools.AssertAreEqual(Vector3.zero, targetRb.velocity);
		}

		[UnityTest]
		public IEnumerator JumpStrength()
		{
			var targetRb = new GameObject("target").AddComponent<Rigidbody>();
			var jumpCtrl = new GameObject("jump").AddComponent<JumpControler>();
			var triggerMock = new GameObject("triggers").AddComponent<TriggersMock>();

			jumpCtrl.strength = 2;
			jumpCtrl.targetRigidbody = new GameObjectWrapper(targetRb.gameObject);
			jumpCtrl.targetTriggers = new GameObjectWrapper(triggerMock.gameObject);
			targetRb.useGravity = false;

			yield return new WaitForEndOfFrame(); // Start

			triggerMock.colliders
				.Add(new GameObject("collider").AddComponent<SphereCollider>());

			jumpCtrl.Jump();

			TestTools.AssertAreEqual(Vector3.up * 2, targetRb.velocity);
		}

		[UnityTest]
		public IEnumerator JumpDirection()
		{
			var targetRb = new GameObject("target").AddComponent<Rigidbody>();
			var jumpCtrl = new GameObject("jump").AddComponent<JumpControler>();
			var triggerMock = new GameObject("triggers").AddComponent<TriggersMock>();

			jumpCtrl.direction = new Vector3(-1, 0, 0);
			jumpCtrl.targetRigidbody = new GameObjectWrapper(targetRb.gameObject);
			jumpCtrl.targetTriggers = new GameObjectWrapper(triggerMock.gameObject);
			targetRb.useGravity = false;

			yield return new WaitForEndOfFrame(); // Start

			triggerMock.colliders
				.Add(new GameObject("collider").AddComponent<SphereCollider>());

			jumpCtrl.Jump();

			TestTools.AssertAreEqual(new Vector3(-1, 0, 0), targetRb.velocity);
		}

		[UnityTest]
		public IEnumerator JumpDirectionNormalized()
		{
			var targetRb = new GameObject("target").AddComponent<Rigidbody>();
			var jumpCtrl = new GameObject("jump").AddComponent<JumpControler>();
			var triggerMock = new GameObject("triggers").AddComponent<TriggersMock>();

			jumpCtrl.direction = new Vector3(0, 1, 1);
			jumpCtrl.targetRigidbody = new GameObjectWrapper(targetRb.gameObject);
			jumpCtrl.targetTriggers = new GameObjectWrapper(triggerMock.gameObject);
			targetRb.useGravity = false;

			yield return new WaitForEndOfFrame(); // Start

			triggerMock.colliders
				.Add(new GameObject("collider").AddComponent<SphereCollider>());

			jumpCtrl.Jump();

			TestTools.AssertAreEqual(
				new Vector3(0, Mathf.Sqrt(2) / 2, Mathf.Sqrt(2) / 2),
				targetRb.velocity
			);
		}
	}
}
