using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class JumpControler : MonoBehaviour
{
	private Rigidbody rb;
	private IEnumerable<Collider> triggers;

	public GameObjectWrapper targetRigidbody;
	public GameObjectWrapper targetTriggers;
	public Vector3 direction = Vector3.up;
	public float strength = 1;

	private void Start()
	{
		this.rb = this.targetRigidbody
			.AssertComponent<Rigidbody>();
		this.triggers = this.targetTriggers
			.AssertComponent<IEnumerable<Collider>>();
	}

	public void Jump()
	{
		if (this.triggers.Any()) {
			this.rb.velocity += this.direction.normalized * this.strength;
		}
	}
}
