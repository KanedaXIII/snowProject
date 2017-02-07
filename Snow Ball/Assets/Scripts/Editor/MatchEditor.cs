using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GameMatch)), CanEditMultipleObjects]
public class MatchEditor : Editor {

    private bool timerToggle = false;

    public SerializedProperty
        levelName_Prop,
        typeMatch_Prop,
        ballTries_Prop,
        scoreGoal_Prop,
        maxTime_Prop;

    void OnEnable()
    {
        levelName_Prop = serializedObject.FindProperty("levelName");
        typeMatch_Prop = serializedObject.FindProperty("typeMatch");
        maxTime_Prop = serializedObject.FindProperty("maxTime");
        scoreGoal_Prop = serializedObject.FindProperty("scoreGoal");
        ballTries_Prop = serializedObject.FindProperty("ballTries");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(levelName_Prop);

        EditorGUILayout.PropertyField(typeMatch_Prop);

        GameMatch.typeMatchList tM = (GameMatch.typeMatchList)typeMatch_Prop.enumValueIndex;

        switch (tM)
        {
            case GameMatch.typeMatchList.TimeMode:
                EditorGUILayout.PropertyField(maxTime_Prop);
                EditorGUILayout.PropertyField(scoreGoal_Prop);
                break;
            case GameMatch.typeMatchList.BallMode:
                EditorGUILayout.PropertyField(ballTries_Prop);
                EditorGUILayout.PropertyField(scoreGoal_Prop);
                timerToggle = EditorGUILayout.Toggle("Timer",timerToggle);
                if (timerToggle)
                {
                    EditorGUILayout.PropertyField(maxTime_Prop);
                }
                break;
            case GameMatch.typeMatchList.InfMode:
                EditorGUILayout.PropertyField(maxTime_Prop);
                break;
        }

        serializedObject.ApplyModifiedProperties();
    }
 }
