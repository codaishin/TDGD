using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputControler : MonoBehaviour
{
	public GetKeyControler getKeyControler;
	public KeyCode key;
	public GetKeyControler.Option option;
	public UnityEvent onKey;

	public void Apply()
	{
		if (this.getKeyControler.GetKey(this.option, this.key)) {
			this.onKey.Invoke();
		}
	}
}
