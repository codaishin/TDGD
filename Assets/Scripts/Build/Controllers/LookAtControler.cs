using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtControler : MonoBehaviour
{
	public GameObjectWrapper target;
	public GameObjectWrapper lookAt;
	public bool invert;

	public void Apply()
	{
		Vector3 targetPos = this.target.GameObject.transform.position;
		Vector3 lookAtPos = this.lookAt.GameObject.transform.position;
		Vector3 lookDir = lookAtPos - targetPos;
		this.target.GameObject.transform
			.LookAt(this.invert ? targetPos - lookDir : targetPos + lookDir);
	}
}
