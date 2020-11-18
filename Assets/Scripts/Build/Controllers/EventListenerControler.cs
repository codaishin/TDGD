using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventListenerControler : MonoBehaviour
{
	private bool added;

	public EventHandle eventHandle;
	public UnityEvent onRaise = new UnityEvent();

	private void Start() => this.Add();

	private void OnEnable() => this.Add();

	private void OnDisable() => this.Remove();

	private void Raise() => this.onRaise.Invoke();

	private void Add()
	{
		if (this.eventHandle && this.added == false) {
			this.eventHandle.OnRaise += this.Raise;
			this.added = true;
		}
	}

	private void Remove()
	{
		if (this.added) {
			this.eventHandle.OnRaise -= this.Raise;
			this.added = false;
		}
	}
}
