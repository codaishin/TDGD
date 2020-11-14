using NUnit.Framework;
using UnityEngine;

public class TestTools : MonoBehaviour
{
	public abstract class BaseTestClass
	{
		[TearDown]
		public void TearDonw()
		{
			foreach (GameObject obj in Object.FindObjectsOfType<GameObject>(true)) {
				Object.Destroy(obj);
			}
		}
	}

	public static void AssertAreEqual(in Vector3 a, in Vector3 b)
	{
		if (a != b) {
			throw new AssertionException(
				$"Expected: ({a.x:F10}, {a.y:F10}, {a.z:F10})\n" +
				$" But was: ({b.x:F10}, {b.y:F10}, {b.z:F10})"
			);
		}
	}

	public static void AssertAreEqual(in Vector3 a, in Vector3 b, in float delta)
	{
		if (Mathf.Abs(a.x - b.x) > delta ||
		    Mathf.Abs(a.y - b.y) > delta ||
		    Mathf.Abs(a.z - b.z) > delta) {
			throw new AssertionException(
				$"Expected: ({a.x:F10}, {a.y:F10}, {a.z:F10})\n" +
				$" But was: ({b.x:F10}, {b.y:F10}, {b.z:F10})\n" +
				$"Allowed delta: {delta:F10}"
			);
		}
	}
}
