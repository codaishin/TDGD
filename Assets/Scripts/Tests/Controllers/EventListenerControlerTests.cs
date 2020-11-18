using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
	public class EventListenerControlerTests : TestTools.BaseTestClass
	{
		[UnityTest]
		public IEnumerator OnRaiseNotNull()
		{
			var eventListenerCtrl = new GameObject("listener")
				.AddComponent<EventListenerControler>();
			eventListenerCtrl.eventHandle = ScriptableObject
				.CreateInstance<EventHandle>();

			yield return new WaitForEndOfFrame();

			Assert.NotNull(eventListenerCtrl.onRaise);
		}

		[UnityTest]
		public IEnumerator OnRaise()
		{
			var called = 0;
			var eventListenerCtrl = new GameObject("listener")
				.AddComponent<EventListenerControler>();
			var eventHandle = ScriptableObject.CreateInstance<EventHandle>();
			eventListenerCtrl.eventHandle = eventHandle;

			yield return new WaitForEndOfFrame();

			eventListenerCtrl.onRaise.AddListener(() => ++called);
			eventHandle.Raise();

			Assert.AreEqual(1, called);
		}
	}
}
