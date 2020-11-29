using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
	public class CursorHandleTests : TestTools.BaseTestClass
	{
		[Test]
		public void Hide()
		{
			var cursorHandle = ScriptableObject.CreateInstance<CursorHandle>();

			cursorHandle.SetVisibility(false);

			Assert.False(Cursor.visible);
		}
	}
}
