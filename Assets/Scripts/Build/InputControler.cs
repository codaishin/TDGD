using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputControler : MonoBehaviour
{
	public enum Option
	{
		Down = default,
		Hold,
		Up,
	}

	public GetKeyControler getKeyControler;
	public KeyCode key;
	public UnityEvent onKey;
	public Option option;

	public void Apply()
	{
		switch (this.option) {
			case InputControler.Option.Down:
				if (this.getKeyControler.GetKeyDown(this.key)) {
					this.onKey.Invoke();
				}
				break;
			case InputControler.Option.Hold:
				if (this.getKeyControler.GetKey(this.key)) {
					this.onKey.Invoke();
				}
				break;
			default:
				if (this.getKeyControler.GetKeyUp(this.key)) {
					this.onKey.Invoke();
				}
				break;
		}
	}
}
