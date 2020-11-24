using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class FloatEvent : UnityEvent<float> {}

public abstract class BaseAxisControler : MonoBehaviour
{
	public string axis;
	public FloatEvent onApply = new FloatEvent();

	protected abstract float GetAxis(in string name);

	public void Apply() => this.onApply.Invoke(this.GetAxis(this.axis));
}

public class AxisControler : BaseAxisControler
{
	protected override float GetAxis(in string name) => Input.GetAxis(name);
}
