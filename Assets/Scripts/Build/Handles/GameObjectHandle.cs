using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/GameObjectHandle")]
public class GameObjectHandle : ScriptableObject
{
	public GameObject GameObject { get; set; }
}
