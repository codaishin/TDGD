using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct GameObjectWrapper
{
	public GameObject gameObject;

	public GameObjectHandle handle;

	public GameObject GameObject => this.gameObject ?? this.handle.GameObject;
}
