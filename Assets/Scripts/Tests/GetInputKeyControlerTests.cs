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
			public bool[] returnCodes = new bool[3];

			public override bool GetKeyDown(in KeyCode keyCode)
			{
				this.wasCalled = GetKeyControler.Option.Down;
				return this.returnCodes[(int)this.wasCalled];
			}

			public override bool GetKeyHold(in KeyCode keyCode)
			{
				this.wasCalled = GetKeyControler.Option.Hold;
				return this.returnCodes[(int)this.wasCalled];
			}

			public override bool GetKeyUp(in KeyCode keyCode)
			{
				this.wasCalled = GetKeyControler.Option.Up;
				return this.returnCodes[(int)this.wasCalled];
			}
		}

		[Test]
		public void OptionDown()
		{
			var option = GetKeyControler.Option.Down;
			var getKeyControler = new GameObject("getKey").AddComponent<GetKeyMock>();
			getKeyControler.GetKey(option, KeyCode.B);

			Assert.AreEqual(option, getKeyControler.wasCalled);
		}

		[Test]
		public void OptionDownReturnCode()
		{
			var option = GetKeyControler.Option.Down;
			var getKeyControler = new GameObject("getKey").AddComponent<GetKeyMock>();
			getKeyControler.returnCodes[(int)option] = true;

			Assert.True(getKeyControler.GetKey(option, KeyCode.B));
		}

		[Test]
		public void OptionHold()
		{
			var option = GetKeyControler.Option.Hold;
			var getKeyControler = new GameObject("getKey").AddComponent<GetKeyMock>();
			getKeyControler.GetKey(option, KeyCode.B);

			Assert.AreEqual(option, getKeyControler.wasCalled);
		}

		[Test]
		public void OptionHoldReturnCode()
		{
			var option = GetKeyControler.Option.Hold;
			var getKeyControler = new GameObject("getKey").AddComponent<GetKeyMock>();
			getKeyControler.returnCodes[(int)option] = true;

			Assert.True(getKeyControler.GetKey(option, KeyCode.B));
		}

		[Test]
		public void OptionUp()
		{
			var option = GetKeyControler.Option.Up;
			var getKeyControler = new GameObject("getKey").AddComponent<GetKeyMock>();
			getKeyControler.GetKey(option, KeyCode.B);

			Assert.AreEqual(option, getKeyControler.wasCalled);
		}

		[Test]
		public void OptionUpReturnCode()
		{
			var option = GetKeyControler.Option.Up;
			var getKeyControler = new GameObject("getKey").AddComponent<GetKeyMock>();
			getKeyControler.returnCodes[(int)option] = true;

			Assert.True(getKeyControler.GetKey(option, KeyCode.B));
		}
	}
}
