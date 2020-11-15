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
			public bool[] returns = new bool[3];
			public override bool GetKeyDown(in KeyCode keyCode) => this.returns[0];
			public override bool GetKeyHold(in KeyCode keyCode) => this.returns[1];
			public override bool GetKeyUp(in KeyCode keyCode) => this.returns[2];
		}

		[Test]
		public void AccessDown()
		{
			var getKeyControler = new GameObject("getKey").AddComponent<GetKeyMock>();
			getKeyControler.returns[0] = true;

			Assert.True(getKeyControler.GetKey(GetKeyControler.Option.Down, KeyCode.B));
		}

		[Test]
		public void AccessHold()
		{
			var getKeyControler = new GameObject("getKey").AddComponent<GetKeyMock>();
			getKeyControler.returns[1] = true;

			Assert.True(getKeyControler.GetKey(GetKeyControler.Option.Hold, KeyCode.B));
		}

		[Test]
		public void AccessUp()
		{
			var getKeyControler = new GameObject("getKey").AddComponent<GetKeyMock>();
			getKeyControler.returns[2] = true;

			Assert.True(getKeyControler.GetKey(GetKeyControler.Option.Up, KeyCode.B));
		}
	}
}
