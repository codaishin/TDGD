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
	}
}
