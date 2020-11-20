using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
	public class GameObjectWrapperTests : TestTools.BaseTestClass
	{
		[Test]
		public void GameObject()
		{
			var obj = new GameObject("obj");
			var wrapper = new GameObjectWrapper();
			wrapper.gameObject = obj;

			Assert.AreSame(obj, wrapper.GameObject);
		}

		[Test]
		public void GameObjectHandle()
		{
			var obj = new GameObject("obj");
			var handle = ScriptableObject.CreateInstance<GameObjectHandle>();
			var wrapper = new GameObjectWrapper();
			handle.GameObject = obj;
			wrapper.handle = handle;

			Assert.AreSame(obj, wrapper.GameObject);
		}
	}
}
