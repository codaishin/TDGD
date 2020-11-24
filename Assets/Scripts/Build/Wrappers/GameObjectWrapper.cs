using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct GameObjectWrapper
{
	private static readonly string msg
		= "GameObjectWrapper has gameObject and handler assigned, only assign one";

	[SerializeField] private GameObject gameObject;
	[SerializeField] private GameObjectHandle handle;

	public GameObject GameObject {
		get {
			if (!this.handle) return this.gameObject;
			if (this.gameObject) throw new ArgumentException(GameObjectWrapper.msg);
			return this.handle.GameObject;
		}
	}

	public GameObjectWrapper(in GameObject gameObject, in GameObjectHandle handle)
	{
		this.gameObject = gameObject;
		this.handle = handle;
	}

	public GameObjectWrapper(in GameObject gameObject) : this(gameObject, null)	{}

	public GameObjectWrapper(in GameObjectHandle handle) : this(null, handle) {}
}
