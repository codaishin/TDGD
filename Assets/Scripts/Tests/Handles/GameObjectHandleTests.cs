using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
	public class GameObjectHandleTests : TestTools.BaseTestClass
	{
		[Test]
		public void GameObject()
		{
			var obj = new GameObject("obj");
			var handle = ScriptableObject.CreateInstance<GameObjectHandle>();

			handle.GameObject = obj;

			Assert.AreSame(obj, handle.GameObject);
		}
	}
}
