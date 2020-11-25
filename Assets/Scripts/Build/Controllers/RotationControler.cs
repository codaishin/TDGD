﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationControler : MonoBehaviour
{
	public GameObjectWrapper target;
	public GameObjectWrapper around;
	public Vector3 axis = Vector3.up;
	public Space space = Space.Self;

	private Vector3 Axis => this.space == Space.Self
		? this.target.GameObject.transform.rotation * this.axis
		: this.axis;

	public void Rotate(float degrees)
	{
		this.target.GameObject.transform.RotateAround(
			this.around.GameObject.transform.position,
			this.Axis,
			degrees
		);
	}
}