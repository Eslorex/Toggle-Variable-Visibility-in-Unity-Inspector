using UnityEngine;
using UnityEditor;
using System.Reflection;

[CustomEditor(typeof(UnityEngine.Object), true)]
public class VariableHider : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        var targetType = target.GetType();

        var fields = targetType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

        foreach (var field in fields)
        {
            var hideInInspector = field.GetCustomAttributes(typeof(HideInInspector), true);

            if (hideInInspector.Length > 0)
            {
                var showVariableProp = serializedObject.FindProperty("showVariable");
                if (showVariableProp == null) continue;

                bool showVariable = showVariableProp.boolValue;

                if (!showVariable)
                {
                    continue;
                }
            }

            EditorGUILayout.PropertyField(serializedObject.FindProperty(field.Name), true);
        }

        serializedObject.ApplyModifiedProperties();
    }
}
