using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(DianaMatch)),CanEditMultipleObjects]
public class MatchesEditor : Editor {

    public SerializedProperty
        dianaOut_Prop,
        dianaMiddle_Prop,
        dianaCenter_Prop,
        scoreGoal_Prop,
        dianaOutTime_Prop,
        dianaMiddleTime_Prop,
        dianaCenterTime_Prop,
        typeDiana_Prop;

    void OnEnable()
    {
        dianaOut_Prop = serializedObject.FindProperty("dianaOut");
        dianaMiddle_Prop = serializedObject.FindProperty("dianaMiddle");
        dianaCenter_Prop = serializedObject.FindProperty("dianaCenter");

        typeDiana_Prop = serializedObject.FindProperty("typeDiana");
        #region Level
        scoreGoal_Prop = serializedObject.FindProperty("scoreGoal");
        #endregion

        #region Infinity
        dianaOutTime_Prop = serializedObject.FindProperty("dianaOutTime");
        dianaMiddleTime_Prop = serializedObject.FindProperty("dianaMiddleTime");
        dianaCenterTime_Prop = serializedObject.FindProperty("dianaCenterTime");
        #endregion
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(dianaOut_Prop);
        EditorGUILayout.PropertyField(dianaMiddle_Prop);
        EditorGUILayout.PropertyField(dianaCenter_Prop);

        EditorGUILayout.PropertyField(typeDiana_Prop);

        DianaMatch.typeDianaList tD = (DianaMatch.typeDianaList)typeDiana_Prop.enumValueIndex;

        switch ( tD )
        {
            case DianaMatch.typeDianaList.Infinity:
                EditorGUILayout.PropertyField(dianaOutTime_Prop);
                EditorGUILayout.PropertyField(dianaMiddleTime_Prop);
                EditorGUILayout.PropertyField(dianaCenterTime_Prop);
                break;
            case DianaMatch.typeDianaList.LevelTime:
                EditorGUILayout.PropertyField(scoreGoal_Prop);

                break;
            case DianaMatch.typeDianaList.LevelBall:

                break;
        }

        serializedObject.ApplyModifiedProperties();
    }

  }
