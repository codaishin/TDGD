using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtControler : MonoBehaviour
{
	public GameObjectWrapper target;
	public GameObjectWrapper lookAt;

	public void Apply()
	{
		this.target.GameObject.transform
			.LookAt(this.lookAt.GameObject.transform.position);
	}
}
