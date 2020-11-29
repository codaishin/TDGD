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
		Vector3 lookDir = lookAtPos - targetPos;
		if (this.restrictionPlaneNormal != Vector3.zero) {
			lookDir = Vector3.ProjectOnPlane(lookDir, this.restrictionPlaneNormal);
		}
		this.target.GameObject.transform
			.LookAt(this.invert ? targetPos - lookDir : targetPos + lookDir);
	}
}
