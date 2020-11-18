using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
	public class TestToolsTests
	{
		[Test]
		public void AlmostEqualVector()
		{
			var a = Vector3.zero;
			var b = new Vector3(float.Epsilon, 0, 0);

			Assert.True(a == b, "was not approximately equal");
			Assert.AreNotEqual(a, b,"was exactly equal");
		}

		[Test]
		public void AssertAreEqualVectorsThrows()
		{
			Assert.Throws<AssertionException>(
				() => TestTools.AssertAreEqual(Vector3.zero, Vector3.one)
			);
		}

		[Test]
		public void AssertAreEqualVectorsIdentical()
		{
			TestTools.AssertAreEqual(Vector3.zero, Vector3.zero);
		}

		[Test]
		public void AssertAreEqualVectorsEssentiallEqual()
		{
			TestTools.AssertAreEqual(Vector3.zero, new Vector3(float.Epsilon, 0, 0));
		}

		[Test]
		public void AssertAreEqualVectorsThrowsMessage()
		{
			try {
				TestTools.AssertAreEqual(Vector3.zero, Vector3.one);
			} catch (AssertionException e) {
				string message =
					"Expected: ({0:F10}, {0:F10}, {0:F10})\n" +
					" But was: ({1:F10}, {1:F10}, {1:F10})";
				Assert.AreEqual(string.Format(message, 0f, 1f), e.Message);
			}
		}

		[Test]
		public void AssertAreEqualVectorsDeltaThrows()
		{
			Assert.Throws<AssertionException>(
				() => TestTools.AssertAreEqual(Vector3.zero, Vector3.one, 0.5f)
			);
		}

		[Test]
		public void AssertAreEqualVectorsDeltaIdenditcal()
		{
			TestTools.AssertAreEqual(Vector3.zero, Vector3.zero, 0.5f);
		}

		[Test]
		public void AssertAreEqualVectorsDeltaEssentiallEqual()
		{
			TestTools.AssertAreEqual(Vector3.zero, new Vector3(0.5f, 0, 0), 0.5f);
		}

		[Test]
		public void AssertAreEqualVectorsDeltaThrowsMessage()
		{
			try {
				TestTools.AssertAreEqual(Vector3.zero, Vector3.one, 0.3f);
			} catch (AssertionException e) {
				string message =
					"Expected: ({0:F10}, {0:F10}, {0:F10})\n" +
					" But was: ({1:F10}, {1:F10}, {1:F10})\n" +
					"Allowed delta: {2:F10}";
				Assert.AreEqual(string.Format(message, 0f, 1f, 0.3f), e.Message);
			}
		}
	}
}
