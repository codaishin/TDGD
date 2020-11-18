using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
	public GameObject target;
	public Vector3 offsetVector;

	private void Update()
	{
		this.UpdateOffsetVector();
		this.UpdateLookRotation();
	}

	private void UpdateOffsetVector()
	{
		this.transform.position =
			this.target.transform.position +
			this.offsetVector;
	}

	private void UpdateLookRotation()
	{
		this.transform.LookAt(this.target.transform);
	}

	public void SetOffsetFromCurrentPosition()
	{
		this.offsetVector =
			this.transform.position -
			this.target.transform.position;
	}
}
