using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
	public class TrackerControlerTests : TestTools.BaseTestClass
	{
		[Test]
		public void Track()
		{
			var target = new GameObject("target");
			var trckCtrl = new GameObject("tracker").AddComponent<TrackerControler>();
			trckCtrl.target = new GameObjectWrapper(target);
			target.transform.position = new Vector3(1, 2, 3);

			trckCtrl.Track();

			Assert.AreEqual(target.transform.position, trckCtrl.transform.position);
		}
	}
}
