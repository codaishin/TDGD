using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackerControler : MonoBehaviour
{
	public GameObjectWrapper target;

	public void Track()
	{
		this.transform.position = this.target.GameObject.transform.position;
	}
}
