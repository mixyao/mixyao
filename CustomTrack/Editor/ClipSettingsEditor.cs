using UnityEngine;
using UnityEditor;

namespace mixyaoCustomTimeLineForGJ2024
{
    [CustomEditor(typeof(ClipSettings))]
    public class ClipSettingsEditor : Editor
    {
        SerializedProperty clipTypeProp;
        SerializedProperty prefabProp, animationClipProp, justPutOutProp, cubeProp;
        SerializedProperty iconPathProp, iconProp, colorProp, sizeProp;

        void OnEnable()
        {
            clipTypeProp = serializedObject.FindProperty("clipType");

            prefabProp = serializedObject.FindProperty("prefab");
            animationClipProp = serializedObject.FindProperty("animationClip");
            justPutOutProp = serializedObject.FindProperty("justPutOut");
            cubeProp = serializedObject.FindProperty("cube");

            iconPathProp = serializedObject.FindProperty("iconPath");
            iconProp = serializedObject.FindProperty("icon");
            colorProp = serializedObject.FindProperty("color");
            sizeProp = serializedObject.FindProperty("size");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(clipTypeProp);

            ClipType clipType = (ClipType)clipTypeProp.enumValueIndex;

            switch (clipType)
            {
                case ClipType.MakeCube:
                    EditorGUILayout.PropertyField(prefabProp);
                    EditorGUILayout.PropertyField(animationClipProp);
                    EditorGUILayout.PropertyField(justPutOutProp);
                    EditorGUILayout.PropertyField(cubeProp);
                    break;

                case ClipType.Event:
                    ClipSettings clipSettings = (ClipSettings)target;
                    EditorGUILayout.LabelField("Message:", clipSettings.message);
                    break;
            }

            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Icon Settings", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(iconPathProp);
            EditorGUILayout.PropertyField(iconProp);
            EditorGUILayout.PropertyField(colorProp);
            EditorGUILayout.PropertyField(sizeProp);

            serializedObject.ApplyModifiedProperties();
        }
    }
}