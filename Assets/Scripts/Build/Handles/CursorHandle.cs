using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/CursorHandle")]
public class CursorHandle : ScriptableObject
{
	public void SetVisibility(bool value) => Cursor.visible = value;
}
