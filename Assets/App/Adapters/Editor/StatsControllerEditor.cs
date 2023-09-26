using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(StatsController), true)]
public class StatsControllerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        IStatsController statsComponent = (IStatsController)target;

        EditorGUILayout.LabelField("Name", statsComponent.Name);

        statsComponent.HP = EditorGUILayout.FloatField("Health", statsComponent.HP);
        statsComponent.MaxHP = EditorGUILayout.FloatField("Max Health", statsComponent.MaxHP);

        statsComponent.MP = EditorGUILayout.FloatField("Mana", statsComponent.MP);
        statsComponent.MaxMP = EditorGUILayout.FloatField("Max Mana", statsComponent.MaxMP);

        statsComponent.SP = EditorGUILayout.FloatField("Stamina", statsComponent.SP);
        statsComponent.MaxSP = EditorGUILayout.FloatField("Max Stamina", statsComponent.MaxSP);

        statsComponent.Speed = EditorGUILayout.FloatField("Speed", statsComponent.Speed);
        statsComponent.MaxSpeed = EditorGUILayout.FloatField("Max Speed", statsComponent.MaxSpeed);

        statsComponent.HP_RecoveryRate = EditorGUILayout.FloatField("HP Recovery Rate", statsComponent.HP_RecoveryRate);
        statsComponent.MP_RecoveryRate = EditorGUILayout.FloatField("MP Recovery Rate", statsComponent.MP_RecoveryRate);
        statsComponent.SP_RecoveryRate = EditorGUILayout.FloatField("SP Recovery Rate", statsComponent.SP_RecoveryRate);

        statsComponent.MP_UsageRate = EditorGUILayout.FloatField("Mana Max Output Rate", statsComponent.MP_UsageRate);
        statsComponent.SP_UsageRate = EditorGUILayout.FloatField("Stamina Max Output Rate", statsComponent.SP_UsageRate);

        GUILayout.Toggle(statsComponent.isAlive, "Alive");

        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Load stats"))
        {
            Undo.RecordObject(target, "Load stats");
            statsComponent.LoadStats();
        }

        if (GUILayout.Button("Restore stats"))
        {
            Undo.RecordObject(target, "Restore stats");
            statsComponent.RestoreStats();
        }

        GUILayout.EndHorizontal();
    }
}
