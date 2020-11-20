using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectHandleSetControler : MonoBehaviour
{
	public GameObjectHandle handle;

	private void Start()
	{
		this.handle.GameObject = this.gameObject;
	}
}
