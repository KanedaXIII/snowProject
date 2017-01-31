using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GameMatch)), CanEditMultipleObjects]
public class MatchEditor : Editor {

    public SerializedProperty
        levelName_Prop,
        typeMatch_Prop,
        maxTime_Prop;

    void OnEnable()
    {
        levelName_Prop = serializedObject.FindProperty("levelName");
        typeMatch_Prop = serializedObject.FindProperty("typeMatch");
        maxTime_Prop = serializedObject.FindProperty("maxTime");
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
                break;
            case GameMatch.typeMatchList.BallMode:
               
                break;
            case GameMatch.typeMatchList.InfMode:
                break;
        }

        serializedObject.ApplyModifiedProperties();
    }
 }
