using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
	public class GetInputKeyControlerTests : TestTools.BaseTestClass
	{
		private class GetKeyMock : GetKeyControler
		{
			public GetKeyControler.Option wasCalled = (GetKeyControler.Option)(-1);
			public override bool GetKeyDown(in KeyCode keyCode)
			{
				this.wasCalled = GetKeyControler.Option.Down;
				return false;
			}

			public override bool GetKeyHold(in KeyCode keyCode)
			{
				this.wasCalled = GetKeyControler.Option.Hold;
				return false;
			}

			public override bool GetKeyUp(in KeyCode keyCode)
			{
				this.wasCalled = GetKeyControler.Option.Up;
				return false;
			}
		}

		[Test]
		public void AccessDown()
		{
			var getKeyControler = new GameObject("getKey").AddComponent<GetKeyMock>();
			getKeyControler.GetKey(GetKeyControler.Option.Down, KeyCode.B);

			Assert.AreEqual(GetKeyControler.Option.Down, getKeyControler.wasCalled);
		}

		[Test]
		public void AccessHold()
		{
			var getKeyControler = new GameObject("getKey").AddComponent<GetKeyMock>();
			getKeyControler.GetKey(GetKeyControler.Option.Hold, KeyCode.B);

			Assert.AreEqual(GetKeyControler.Option.Hold, getKeyControler.wasCalled);
		}

		[Test]
		public void AccessUp()
		{
			var getKeyControler = new GameObject("getKey").AddComponent<GetKeyMock>();
			getKeyControler.GetKey(GetKeyControler.Option.Up, KeyCode.B);

			Assert.AreEqual(GetKeyControler.Option.Up, getKeyControler.wasCalled);
		}
	}
}
