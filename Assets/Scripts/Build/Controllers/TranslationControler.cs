using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslationControler : MonoBehaviour
{
	public GameObjectWrapper target;
	public Vector3 vector;

	public void Translate() => this.Translate(1f);

	public void TranslateDelta() => this.Translate(Time.deltaTime);

	public void TranslateFixedDelta() => this.Translate(Time.fixedDeltaTime);

	public void Translate(float scale)
	{
		this.target.GameObject.transform.Translate(this.vector * scale);
	}
}
