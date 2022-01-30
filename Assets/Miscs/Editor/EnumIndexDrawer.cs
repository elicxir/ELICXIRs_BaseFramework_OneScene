using System;
using System.Linq;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(EnumIndexAttribute))]
class EnumIndexDrawer : PropertyDrawer
{
    public override void OnGUI(Rect rect, SerializedProperty property, GUIContent label)
    {
        var names = ((EnumIndexAttribute)attribute)._names;
        // propertyPath returns something like hogehoge.Array.data[0]
        // so get the index from there.
        var index = int.Parse(property.propertyPath.Split('[', ']').Where(c => !string.IsNullOrEmpty(c)).Last());
        if (index < names.Length) label.text = names[index];
        EditorGUI.PropertyField(rect, property, label, includeChildren: true);
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return EditorGUI.GetPropertyHeight(property, label, includeChildren: true);
    }
}
