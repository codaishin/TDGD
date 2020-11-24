using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationControler : MonoBehaviour
{
	public GameObjectWrapper around;

	public void Rotate(float degrees)
	{
		this.transform.RotateAround(
			this.around.GameObject.transform.position,
			Vector3.up,
			degrees
		);
	}
}
