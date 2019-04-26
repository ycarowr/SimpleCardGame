using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using SimpleCardGames.Data.Effects;

[CustomEditor(typeof(BaseEffectData), true)]
public class EffectDataEditor : Editor
{
    BaseEffectData MyTarget { get { return target as BaseEffectData; } }
    Vector2Int Position { get; set; }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (EditorApplication.isPlaying)
        {
            GUILayout.Space(10);
            GUILayout.Label("Playmode: Debug");
            GUILayout.BeginHorizontal();
            Position = EditorGUILayout.Vector2IntField("Position: ", Position, GUILayout.Width(100));
            
            if (GUILayout.Button("Resolve Targets"))
            {
                //ResolveTargets();
            }
            GUILayout.EndHorizontal();
        }
    }
}
