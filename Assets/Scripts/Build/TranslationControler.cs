using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslationControler : MonoBehaviour
{
	public GameObject target;
	public Vector3 vector;

	public void Translate() => this.Translate(1f);

	public void Translate(float value)
	{
		this.target.transform.Translate(this.vector * value);
	}
}
