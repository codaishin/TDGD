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
			translationCtrl.target = new GameObject("target");
			translationCtrl.vector = new Vector3(0, 1, 0);

			translationCtrl.Translate();

			Assert.AreEqual(
				new Vector3(0, 1, 0),
				translationCtrl.target.transform.position
			);
		}

		[Test]
		public void TranslateNonZero()
		{
			var translationCtrl = new GameObject("obj")
				.AddComponent<TranslationControler>();
			translationCtrl.target = new GameObject("target");
			translationCtrl.vector = new Vector3(0, 1, 0);
			translationCtrl.target.transform.position = new Vector3(1, 2, 3);

			translationCtrl.Translate();

			Assert.AreEqual(
				new Vector3(1, 3, 3),
				translationCtrl.target.transform.position
			);
		}

		[Test]
		public void TranslateForward()
		{
			var translationCtrl = new GameObject("obj")
				.AddComponent<TranslationControler>();
			translationCtrl.target = new GameObject("target");
			translationCtrl.vector = Vector3.forward;

			translationCtrl.Translate();

			Assert.AreEqual(
				Vector3.forward,
				translationCtrl.target.transform.position
			);
		}

		[Test]
		public void TranslateForwardAfterRotation()
		{
			var translationCtrl = new GameObject("obj")
				.AddComponent<TranslationControler>();
			translationCtrl.target = new GameObject("target");
			translationCtrl.vector = Vector3.forward;

			translationCtrl.target.transform.LookAt(Vector3.up);

			translationCtrl.Translate();

			Assert.True(Vector3.up == translationCtrl.target.transform.position);
		}

		[Test]
		public void TranslateValue()
		{
			var translationCtrl = new GameObject("obj")
				.AddComponent<TranslationControler>();
			translationCtrl.target = new GameObject("target");
			translationCtrl.vector = Vector3.forward;

			translationCtrl.Translate(0.5f);

			Assert.AreEqual(
				Vector3.forward / 2,
				translationCtrl.target.transform.position
			);
		}

		[UnityTest]
		public IEnumerator TranslateTimeDelta()
		{
			var delta = Time.deltaTime;
			var translationCtrl = new GameObject("obj")
				.AddComponent<TranslationControler>();
			translationCtrl.target = new GameObject("target");
			translationCtrl.vector = Vector3.forward;

			translationCtrl.TranslateDelta();

			Assert.AreEqual(
				Vector3.forward * delta,
				translationCtrl.target.transform.position
			);

			yield break;
		}

		[UnityTest]
		public IEnumerator TranslateTimeFixedDelta()
		{
			var delta = Time.fixedDeltaTime;
			var translationCtrl = new GameObject("obj")
				.AddComponent<TranslationControler>();
			translationCtrl.target = new GameObject("target");
			translationCtrl.vector = Vector3.forward;

			translationCtrl.TranslateFixedDelta();

			Assert.AreEqual(
				Vector3.forward * delta,
				translationCtrl.target.transform.position
			);

			yield break;
		}
	}
}
