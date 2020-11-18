using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
	public class EventHandleTests : TestTools.BaseTestClass
	{
		[Test]
		public void OnRaise()
		{
			var called = 0;
			var eventHandle = ScriptableObject.CreateInstance<EventHandle>();
			eventHandle.OnRaise += () => ++called;
			eventHandle.Raise();

			Assert.AreEqual(1, called);
		}

		[Test]
		public void OnRaiseEmptyNoThrow()
		{
			var eventHandle = ScriptableObject.CreateInstance<EventHandle>();
			Assert.DoesNotThrow(() => eventHandle.Raise());
		}
	}
}
