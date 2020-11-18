using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/EventHandle")]
public class EventHandle : ScriptableObject
{
	public event Action OnRaise;

	public void Raise() => this.OnRaise?.Invoke();
}
