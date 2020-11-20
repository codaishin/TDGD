using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
	public class GameObjectHandleSetControlerTests : TestTools.BaseTestClass
	{
		[UnityTest]
		public IEnumerator SetGameObject()
		{
			var handle = ScriptableObject.CreateInstance<GameObjectHandle>();
			var setter = new GameObject("obj")
				.AddComponent<GameObjectHandleSetControler>();
			setter.handle = handle;

			yield return new WaitForEndOfFrame();

			Assert.AreSame(setter.gameObject, handle.GameObject);
		}
	}
}
