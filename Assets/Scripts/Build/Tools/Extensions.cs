using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
	public static C AssertComponent<C>(this GameObject obj)
	{
		if (obj.TryGetComponent(out C c)) return c;
		throw new KeyNotFoundException($"\"{typeof(C)}\" not found on \"{obj.name}\"");
	}

	public static C AssertComponent<C>(this GameObjectWrapper handle)
		=> handle.GameObject.AssertComponent<C>();
}
