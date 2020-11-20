using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(GameObjectWrapper))]
public class GameObjectWrapperDrawer : PropertyDrawer
{
	private static
	(bool, bool) State(in SerializedProperty a, in SerializedProperty b)
	{
		if (a.objectReferenceValue) return (true, false);
		if (b.objectReferenceValue) return (false, true);
		return (true, true);
	}

	public override
	float GetPropertyHeight(SerializedProperty property, GUIContent label)
	{
		return EditorGUI.GetPropertyHeight(property, label, true) * 2 / 3;
	}

	public override
	void OnGUI(Rect pos, SerializedProperty property, GUIContent label)
	{
		SerializedProperty obj = property.FindPropertyRelative("gameObject");
		SerializedProperty handle = property.FindPropertyRelative("handle");
		(bool sObj, bool sHandle) = GameObjectWrapperDrawer.State(obj, handle);

		pos = EditorGUI.PrefixLabel(pos, label);
		GUI.enabled = sObj;
		EditorGUI.PropertyField(pos, obj, GUIContent.none, true);
		pos = new Rect(pos.x, pos.y + pos.height / 2, pos.width, pos.height);
		GUI.enabled = sHandle;
		EditorGUI.PropertyField(pos, handle, GUIContent.none, true);
		GUI.enabled = true;
	}
}
