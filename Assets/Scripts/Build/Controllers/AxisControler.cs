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
	public bool invert;
	public float factor = 1f;
	public FloatEvent onApply = new FloatEvent();

	protected abstract float GetAxis(in string name);

	public void Apply()
	{
		float value = this.GetAxis(this.axis) * this.factor;
		this.onApply.Invoke(this.invert ? -value : value);
	}
}

public class AxisControler : BaseAxisControler
{
	protected override float GetAxis(in string name) => Input.GetAxis(name);
}
