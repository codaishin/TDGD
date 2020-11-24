using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationControler : MonoBehaviour
{
	public GameObjectWrapper around;
	public Vector3 axis = Vector3.up;

	public void Rotate(float degrees)
	{
		this.transform.RotateAround(
			this.around.GameObject.transform.position,
			this.axis,
			degrees
		);
	}
}
