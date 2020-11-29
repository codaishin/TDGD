using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtControler : MonoBehaviour
{
	public GameObjectWrapper target;
	public GameObjectWrapper lookAt;
	public bool invert;
	public Vector3 restrictionPlaneNormal;

	public void Apply()
	{
		Vector3 targetPos = this.target.GameObject.transform.position;
		Vector3 lookAtPos = this.lookAt.GameObject.transform.position;
		Vector3 lookDir = this.Invert(this.Restrict(lookAtPos - targetPos));
		this.target.GameObject.transform.LookAt(targetPos + lookDir);
	}

	private Vector3 Invert(in Vector3 lookDirection)
	{
		if (this.invert) {
			return -lookDirection;
		}
		return lookDirection;
	}

	private Vector3 Restrict(in Vector3 lookDirection)
	{
		if (this.restrictionPlaneNormal != Vector3.zero) {
			return Vector3.ProjectOnPlane(lookDirection, this.restrictionPlaneNormal);
		}
		return lookDirection;
	}
}
