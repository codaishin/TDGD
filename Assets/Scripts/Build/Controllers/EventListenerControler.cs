using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventListenerControler : MonoBehaviour
{
	public EventHandle eventHandle;
	public UnityEvent onRaise = new UnityEvent();

	private void Start()
	{
		this.eventHandle.OnRaise += this.onRaise.Invoke;
	}

	private void OnDisable()
	{
		this.eventHandle.OnRaise -= this.onRaise.Invoke;
	}

	private void OnEnable()
	{
		if (this.eventHandle) {
			this.eventHandle.OnRaise += this.onRaise.Invoke;
		}
	}
}
