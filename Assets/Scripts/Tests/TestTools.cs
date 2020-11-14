using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;

public static class TestTools
{
	public abstract class BaseTestClass
	{
		[TearDown]
		public void TearDown()
		{
			foreach (GameObject obj in Object.FindObjectsOfType<GameObject>(true)) {
				Object.Destroy(obj);
			}
		}
	}

	public static void AssertAreEqual(in Vector3 expected, in Vector3 actual)
	{
		if (expected != actual) {
			throw new AssertionException(
				$"Expected: ({expected.x:F10}, {expected.y:F10}, {expected.z:F10})\n" +
				$" But was: ({actual.x:F10}, {actual.y:F10}, {actual.z:F10})"
			);
		}
	}

	public static
	void AssertAreEqual(in Vector3 expected, in Vector3 actual, float delta)
	{
		bool greaterThanDelta(float dimension) => Mathf.Abs(dimension) > delta;

		if (TestTools.DimensionsOf(expected - actual).Any(greaterThanDelta)) {
			throw new AssertionException(
				$"Expected: ({expected.x:F10}, {expected.y:F10}, {expected.z:F10})\n" +
				$" But was: ({actual.x:F10}, {actual.y:F10}, {actual.z:F10})\n" +
				$"Allowed delta: {delta:F10}"
			);
		}
	}

	private static IEnumerable<float> DimensionsOf(Vector3 vector)
	{
		yield return vector.x;
		yield return vector.y;
		yield return vector.z;
	}
}
