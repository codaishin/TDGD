using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandle : ScriptableObject
{
	public event Action OnRaise;

	public void Raise() => this.OnRaise?.Invoke();
}
