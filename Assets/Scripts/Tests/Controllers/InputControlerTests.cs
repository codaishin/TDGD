using System.Linq;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
	public class InputControlerTests : TestTools.BaseTestClass
	{
		private class GetKeyMock : GetKeyControler
		{
			public List<KeyCode> down = new List<KeyCode>();
			public List<KeyCode> hold = new List<KeyCode>();
			public List<KeyCode> up = new List<KeyCode>();

			public override
			bool GetKeyDown(in KeyCode keyCode) => this.down.Contains(keyCode);

			public override
			bool GetKeyHold(in KeyCode keyCode) => this.hold.Contains(keyCode);

			public override
			bool GetKeyUp(in KeyCode keyCode) => this.up.Contains(keyCode);
		}

		[Test]
		public void ApplyEventWhenPressed()
		{
			var called = 0;
			var getKeyControler = new GameObject("getKey").AddComponent<GetKeyMock>();
			var inputCtrl = new GameObject("input").AddComponent<InputControler>();

			getKeyControler.down.Add(KeyCode.A);
			inputCtrl.getKeyControler = getKeyControler;
			inputCtrl.key = KeyCode.A;
			inputCtrl.onKey.AddListener(() => ++called);

			inputCtrl.Apply();

			Assert.AreEqual(1, called);
		}

		[Test]
		public void ApplyNoEventWhenNotPressed()
		{
			var called = 0;
			var getKeyControler = new GameObject("getKey").AddComponent<GetKeyMock>();
			var inputCtrl = new GameObject("input").AddComponent<InputControler>();

			inputCtrl.getKeyControler = getKeyControler;
			inputCtrl.key = KeyCode.A;
			inputCtrl.onKey.AddListener(() => ++called);

			inputCtrl.Apply();

			Assert.AreEqual(0, called);
		}

		[Test]
		public void ApplyEventWhenHeld()
		{
			var called = 0;
			var getKeyControler = new GameObject("getKey").AddComponent<GetKeyMock>();
			var inputCtrl = new GameObject("input").AddComponent<InputControler>();

			getKeyControler.hold.Add(KeyCode.A);
			inputCtrl.getKeyControler = getKeyControler;
			inputCtrl.key = KeyCode.A;
			inputCtrl.onKey.AddListener(() => ++called);
			inputCtrl.option = GetKeyControler.Option.Hold;

			inputCtrl.Apply();

			Assert.AreEqual(1, called);
		}

		[Test]
		public void ApplyNoEventWhenNotHeld()
		{
			var called = 0;
			var getKeyControler = new GameObject("getKey").AddComponent<GetKeyMock>();
			var inputCtrl = new GameObject("input").AddComponent<InputControler>();

			inputCtrl.getKeyControler = getKeyControler;
			inputCtrl.key = KeyCode.A;
			inputCtrl.onKey.AddListener(() => ++called);
			inputCtrl.option = GetKeyControler.Option.Hold;

			inputCtrl.Apply();

			Assert.AreEqual(0, called);
		}

		[Test]
		public void ApplyEventWhenReleased()
		{
			var called = 0;
			var getKeyControler = new GameObject("getKey").AddComponent<GetKeyMock>();
			var inputCtrl = new GameObject("input").AddComponent<InputControler>();

			getKeyControler.up.Add(KeyCode.A);
			inputCtrl.getKeyControler = getKeyControler;
			inputCtrl.key = KeyCode.A;
			inputCtrl.onKey.AddListener(() => ++called);
			inputCtrl.option = GetKeyControler.Option.Up;

			inputCtrl.Apply();

			Assert.AreEqual(1, called);
		}

		[Test]
		public void ApplyNoEventWhenNoReleased()
		{
			var called = 0;
			var getKeyControler = new GameObject("getKey").AddComponent<GetKeyMock>();
			var inputCtrl = new GameObject("input").AddComponent<InputControler>();

			inputCtrl.getKeyControler = getKeyControler;
			inputCtrl.key = KeyCode.A;
			inputCtrl.onKey.AddListener(() => ++called);
			inputCtrl.option = GetKeyControler.Option.Up;

			inputCtrl.Apply();

			Assert.AreEqual(0, called);
		}
	}
}
