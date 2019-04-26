using SimpleCardGames.Data.Effects;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BaseEffectData), true)]
public class EffectDataEditor : Editor
{
    private BaseEffectData MyTarget => target as BaseEffectData;
    private Vector2Int Position { get; set; }

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