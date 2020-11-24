using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
	public class AxisControlerTests :  TestTools.BaseTestClass
	{
		private class AxisMock : BaseAxisControler
		{
			public Dictionary<string, float> axisValues;

			protected override
			float GetAxis(in string axisName) => this.axisValues[axisName];
		}

		[Test]
		public void OnApplyNotNull()
		{
			var axisCtrl = new GameObject("axis").AddComponent<AxisMock>();
			Assert.NotNull(axisCtrl.onApply);
		}

		[Test]
		public void Apply()
		{
			var called = 0f;
			var axisCtrl = new GameObject("axis").AddComponent<AxisMock>();
			axisCtrl.axisValues = new Dictionary<string, float> {
				{ "vertical", 0.3f },
			};
			axisCtrl.onApply.AddListener(v => called = v);
			axisCtrl.axis = "vertical";

			axisCtrl.Apply();

			Assert.AreEqual(0.3f, called);
		}

		[Test]
		public void ApplyAlternative()
		{
			var called = 0f;
			var axisCtrl = new GameObject("axis").AddComponent<AxisMock>();
			axisCtrl.axisValues = new Dictionary<string, float> {
				{ "vertical", 0.3f },
				{ "horizontal", 0.7f },
			};
			axisCtrl.onApply.AddListener(v => called = v);
			axisCtrl.axis = "horizontal";

			axisCtrl.Apply();

			Assert.AreEqual(0.7f, called);
		}
	}
}
