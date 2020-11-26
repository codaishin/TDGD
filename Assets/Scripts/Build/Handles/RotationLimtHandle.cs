using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RotationLimtHandle : ScriptableObject
{
	public abstract
	float Limit(in float angle, in Vector3 offset, in Vector3 axis);
}

public class RotationStaticLimitHandle : RotationLimtHandle
{
	public Vector3 levelPlaneNormal;
	public float max;
	public float min;

	public override
	float Limit(in float angle, in Vector3 offset, in Vector3 axis)
	{
		Vector3 level = Vector3.Cross(axis, this.levelPlaneNormal);
		float currentAngle = Vector3.Angle(level, offset);
		float targetAngle = currentAngle + angle;
		if (targetAngle > this.max) return this.max - currentAngle;
		if (targetAngle < this.min) return this.min - currentAngle;
		return angle;
	}
}
