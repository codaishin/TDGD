using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
	public class ExtensionsTests : TestTools.BaseTestClass
	{
		[Test]
		public void AssertComponentTrue()
		{
			var obj = new GameObject("obj");
			var rb = obj.AddComponent<Rigidbody>();

			var actual = obj.AssertComponent<Rigidbody>();

			Assert.AreSame(rb, actual);
		}

		[Test]
		public void AssertComponentThrows()
		{
			var obj = new GameObject("obj");

			Assert.Throws<KeyNotFoundException>(() => obj.AssertComponent<Rigidbody>());
		}

		[Test]
		public void AssertComponentThrowsMessage()
		{
			var obj = new GameObject("obj");

			try {
				obj.AssertComponent<Rigidbody>();
			} catch (KeyNotFoundException e) {
				Assert.AreEqual("\"UnityEngine.Rigidbody\" not found on \"obj\"", e.Message);
			}
		}
	}
}
