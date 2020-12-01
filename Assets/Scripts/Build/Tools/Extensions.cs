using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
	public static C AssertComponent<C>(this GameObject obj)
		where C: Component
	{
		if (obj.TryGetComponent(out C c)) return c;
		throw new KeyNotFoundException($"\"{typeof(C)}\" not found on \"{obj.name}\"");
	}

	public static C AssertComponent<C>(this GameObjectHandle handle)
		where C: Component => handle.GameObject.AssertComponent<C>();
}
