using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
	public class TranslationControlerTests : TestTools.BaseTestClass
	{
		[Test]
		public void Translate()
		{
			var translationCtrl = new GameObject("obj")
				.AddComponent<TranslationControler>();
			translationCtrl.target = new GameObjectWrapper(new GameObject("target"), null);
			translationCtrl.vector = new Vector3(0, 1, 0);

			translationCtrl.Translate();

			TestTools.AssertAreEqual(
				new Vector3(0, 1, 0),
				translationCtrl.target.GameObject.transform.position
			);
		}

		[Test]
		public void TranslateNonZero()
		{
			var translationCtrl = new GameObject("obj")
				.AddComponent<TranslationControler>();
			translationCtrl.target = new GameObjectWrapper(new GameObject("target"), null);
			translationCtrl.vector = new Vector3(0, 1, 0);
			translationCtrl.target.GameObject.transform.position = new Vector3(1, 2, 3);

			translationCtrl.Translate();

			TestTools.AssertAreEqual(
				new Vector3(1, 3, 3),
				translationCtrl.target.GameObject.transform.position
			);
		}

		[Test]
		public void TranslateForward()
		{
			var translationCtrl = new GameObject("obj")
				.AddComponent<TranslationControler>();
			translationCtrl.target = new GameObjectWrapper(new GameObject("target"), null);
			translationCtrl.vector = Vector3.forward;

			translationCtrl.Translate();

			TestTools.AssertAreEqual(
				Vector3.forward,
				translationCtrl.target.GameObject.transform.position
			);
		}

		[Test]
		public void TranslateForwardAfterRotation()
		{
			var translationCtrl = new GameObject("obj")
				.AddComponent<TranslationControler>();
			translationCtrl.target = new GameObjectWrapper(new GameObject("target"), null);
			translationCtrl.vector = Vector3.forward;

			translationCtrl.target.GameObject.transform.LookAt(Vector3.up);

			translationCtrl.Translate();

			TestTools.AssertAreEqual(
				Vector3.up,
				translationCtrl.target.GameObject.transform.position
			);
		}

		[Test]
		public void TranslateValue()
		{
			var translationCtrl = new GameObject("obj")
				.AddComponent<TranslationControler>();
			translationCtrl.target = new GameObjectWrapper(new GameObject("target"), null);
			translationCtrl.vector = Vector3.forward;

			translationCtrl.Translate(0.5f);

			TestTools.AssertAreEqual(
				Vector3.forward / 2,
				translationCtrl.target.GameObject.transform.position
			);
		}

		[UnityTest]
		public IEnumerator TranslateTimeDelta()
		{
			var delta = Time.deltaTime;
			var translationCtrl = new GameObject("obj")
				.AddComponent<TranslationControler>();
			translationCtrl.target = new GameObjectWrapper(new GameObject("target"), null);
			translationCtrl.vector = Vector3.forward;

			translationCtrl.TranslateDelta();

			TestTools.AssertAreEqual(
				Vector3.forward * delta,
				translationCtrl.target.GameObject.transform.position
			);

			yield break;
		}

		[UnityTest]
		public IEnumerator TranslateTimeFixedDelta()
		{
			var delta = Time.fixedDeltaTime;
			var translationCtrl = new GameObject("obj")
				.AddComponent<TranslationControler>();
			translationCtrl.target = new GameObjectWrapper(new GameObject("target"), null);
			translationCtrl.vector = Vector3.forward;

			translationCtrl.TranslateFixedDelta();

			TestTools.AssertAreEqual(
				Vector3.forward * delta,
				translationCtrl.target.GameObject.transform.position
			);

			yield break;
		}
	}
}
