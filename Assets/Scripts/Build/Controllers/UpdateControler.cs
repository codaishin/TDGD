using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UpdateControler : MonoBehaviour
{
	public UnityEvent onUpdate = new UnityEvent();
	public UnityEvent onFixedUpdate = new UnityEvent();

	private void Update()
	{
		this.onUpdate.Invoke();
	}

	private void FixedUpdate()
	{
		this.onFixedUpdate.Invoke();
	}
}
