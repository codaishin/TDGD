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

	private static void Draw(in Rect position,
	                         in SerializedProperty property,
	                         in bool state,
	                         out Rect newPosition)
	{
		GUI.enabled = state;
		EditorGUI.PropertyField(position, property, GUIContent.none, true);
		newPosition = new Rect(
			position.x,
			position.y + position.height / 2,
			position.width,
			position.height
		);
	}

	public override
	float GetPropertyHeight(SerializedProperty property, GUIContent label)
	{
		return EditorGUI.GetPropertyHeight(property, label, true) * 2 / 3;
	}

	public override
	void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		SerializedProperty obj = property.FindPropertyRelative("gameObject");
		SerializedProperty hnd = property.FindPropertyRelative("handle");
		(bool stObj, bool stHnd) = GameObjectWrapperDrawer.State(obj, hnd);

		position = EditorGUI.PrefixLabel(position, label);
		GameObjectWrapperDrawer.Draw(position, obj, stObj, out position);
		GameObjectWrapperDrawer.Draw(position, hnd, stHnd, out _);
		GUI.enabled = true;
	}
}
