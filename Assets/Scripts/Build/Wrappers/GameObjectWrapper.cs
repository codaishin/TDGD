using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct GameObjectWrapper
{
	private static readonly string msg
		= "GameObjectWrapper has gameObject and handler assigned, only assign one";

	public GameObject gameObject;

	public GameObjectHandle handle;

	public GameObject GameObject {
		get {
			if (!this.handle) return this.gameObject;
			if (this.gameObject) throw new ArgumentException(GameObjectWrapper.msg);
			return this.handle.GameObject;
		}
	}
}
