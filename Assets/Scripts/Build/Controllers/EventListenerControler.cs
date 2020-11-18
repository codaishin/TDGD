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
		this.eventHandle.OnRaise += this.Raise;
	}

	private void Raise()
	{
		if (this.gameObject.activeSelf) {
			this.onRaise.Invoke();
		}
	}
}
