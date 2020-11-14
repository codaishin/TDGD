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
}
