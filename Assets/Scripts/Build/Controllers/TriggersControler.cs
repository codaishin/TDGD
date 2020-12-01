using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggersControler : MonoBehaviour, IEnumerable<Collider>
{
	private Dictionary<int, Collider> colliders = new Dictionary<int, Collider>();

	public IEnumerator<Collider> GetEnumerator()
	{
		foreach (Collider collider in this.colliders.Values) {
			yield return collider;
		}
	}

	IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

	private void OnTriggerEnter(Collider other)
	{
		this.colliders.Add(other.GetInstanceID(), other);
	}

	private void OnTriggerExit(Collider other)
	{
		this.colliders.Remove(other.GetInstanceID());
	}
}
