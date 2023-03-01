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

        var fields = targetType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

        foreach (var field in fields)
        {
            var hideInInspector = field.GetCustomAttributes(typeof(HideInInspector), true);

            if (hideInInspector.Length > 0)
            {
                var showVariableField = targetType.GetField("showVariable", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

                if (showVariableField != null)
                {
                    bool showVariable = (bool)showVariableField.GetValue(target);
                    
                    if (!showVariable)
                    {
                        continue;
                    }
                }
                else
                {
                    continue;
                }
            }
            
            EditorGUILayout.PropertyField(serializedObject.FindProperty(field.Name), true);
        }

        serializedObject.ApplyModifiedProperties();
    }
}
