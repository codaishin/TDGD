using NUnit.Framework;
using UnityEngine;

public class TestTools : MonoBehaviour
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
	void AssertAreEqual(in Vector3 expected, in Vector3 actual, in float delta)
	{
		if (Mathf.Abs(expected.x - actual.x) > delta ||
		    Mathf.Abs(expected.y - actual.y) > delta ||
		    Mathf.Abs(expected.z - actual.z) > delta) {
			throw new AssertionException(
				$"Expected: ({expected.x:F10}, {expected.y:F10}, {expected.z:F10})\n" +
				$" But was: ({actual.x:F10}, {actual.y:F10}, {actual.z:F10})\n" +
				$"Allowed delta: {delta:F10}"
			);
		}
	}
}
