﻿using System.Collections;
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
			var wrapper = new GameObjectWrapper(obj);

			Assert.AreSame(obj, wrapper.GameObject);
		}

		[Test]
		public void GameObjectHandle()
		{
			var obj = new GameObject("obj");
			var handle = ScriptableObject.CreateInstance<GameObjectHandle>();
			var wrapper = new GameObjectWrapper(handle);
			handle.GameObject = obj;

			Assert.AreSame(obj, wrapper.GameObject);
		}

		[Test]
		public void GameObjectHandleConflict()
		{
			var obj = new GameObject("obj");
			var handle = ScriptableObject.CreateInstance<GameObjectHandle>();
			var wrapper = new GameObjectWrapper(obj, handle);
			handle.GameObject = obj;

			Assert.Throws<System.ArgumentException>(() => {
				var _ = wrapper.GameObject;
			});
		}

		[Test]
		public void GameObjectHandleConflictMessage()
		{
			var obj = new GameObject("obj");
			var handle = ScriptableObject.CreateInstance<GameObjectHandle>();
			var wrapper = new GameObjectWrapper(obj, handle);
			handle.GameObject = obj;

			try {
				var _ = wrapper.GameObject;
			} catch (System.ArgumentException e) {
				string msg =
					"GameObjectWrapper has gameObject and handler assigned, " +
					"only assign one";
				Assert.AreEqual(msg, e.Message);
			}
		}
	}
}
