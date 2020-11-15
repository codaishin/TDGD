using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputControler : MonoBehaviour
{
	public GetKeyControler getKeyControler;
	public KeyCode key;
	public UnityEvent onKey;

	public void Apply()
	{
		if (this.getKeyControler.GetKeyDown(this.key)) {
			this.onKey.Invoke();
		}
	}
}
