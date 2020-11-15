using System.Linq;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.TestTools;

namespace Tests
{
	public class InputControlerTests : TestTools.BaseTestClass
	{
		private class GetKeyMock : GetKeyControler
		{
			public List<KeyCode> begin = new List<KeyCode>();
			public List<KeyCode> stay = new List<KeyCode>();
			public List<KeyCode> end = new List<KeyCode>();

			public override
			bool GetKeyDown(in KeyCode keyCode) => this.begin.Contains(keyCode);

			public override
			bool GetKey(in KeyCode keyCode) => this.stay.Contains(keyCode);

			public override
			bool GetKeyUp(in KeyCode keyCode) => this.end.Contains(keyCode);
		}

		[Test]
		public void ApplyEventWhenPressed()
		{
			var called = 0;
			var getKeyControler = new GameObject("getKey").AddComponent<GetKeyMock>();
			var inputCtrl = new GameObject("input").AddComponent<InputControler>();

			getKeyControler.begin.Add(KeyCode.A);
			inputCtrl.getKeyControler = getKeyControler;
			inputCtrl.key = KeyCode.A;
			inputCtrl.onKey = new UnityEvent();
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
			inputCtrl.onKey = new UnityEvent();
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

			getKeyControler.stay.Add(KeyCode.A);
			inputCtrl.getKeyControler = getKeyControler;
			inputCtrl.key = KeyCode.A;
			inputCtrl.onKey = new UnityEvent();
			inputCtrl.onKey.AddListener(() => ++called);
			inputCtrl.option = InputControler.Option.Hold;

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
			inputCtrl.onKey = new UnityEvent();
			inputCtrl.onKey.AddListener(() => ++called);
			inputCtrl.option = InputControler.Option.Hold;

			inputCtrl.Apply();

			Assert.AreEqual(0, called);
		}

		[Test]
		public void ApplyEventWhenReleased()
		{
			var called = 0;
			var getKeyControler = new GameObject("getKey").AddComponent<GetKeyMock>();
			var inputCtrl = new GameObject("input").AddComponent<InputControler>();

			getKeyControler.end.Add(KeyCode.A);
			inputCtrl.getKeyControler = getKeyControler;
			inputCtrl.key = KeyCode.A;
			inputCtrl.onKey = new UnityEvent();
			inputCtrl.onKey.AddListener(() => ++called);
			inputCtrl.option = InputControler.Option.Up;

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
			inputCtrl.onKey = new UnityEvent();
			inputCtrl.onKey.AddListener(() => ++called);
			inputCtrl.option = InputControler.Option.Up;

			inputCtrl.Apply();

			Assert.AreEqual(0, called);
		}
	}
}
