using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorHandle : ScriptableObject
{
	public void SetVisibility(bool value) => Cursor.visible = value;
}
