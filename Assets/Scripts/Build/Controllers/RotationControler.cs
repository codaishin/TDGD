using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationControler : MonoBehaviour
{
	public GameObjectWrapper target;
	public GameObjectWrapper around;
	public Vector3 axis = Vector3.up;
	public Space space = Space.Self;
	public RotationLimitHandle limiter;

	private Vector3 Axis => this.space == Space.Self
		? this.target.GameObject.transform.rotation * this.axis
		: this.axis;

	private Vector3 Offset =>
		around.GameObject.transform.position -
		target.GameObject.transform.position;

	private Vector3 AroundPosition =>
		this.around.GameObject.transform.position;

	public void Rotate(float degrees)
	{
		Vector3 axis = this.Axis;
		if (this.limiter) {
			degrees = limiter.Limit(degrees, this.Offset, axis);
		}
		this.target.GameObject.transform
			.RotateAround(this.AroundPosition, axis, degrees);
	}
}
