using System.Linq;
using SimpleCardGames.Data.Effects;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EffectsSet))]
public class CardDataEffectsEditor : Editor
{
    private EffectTriggerType ChosenTrigger = EffectTriggerType.OnPlay;

    //cell sizes
    private readonly GUILayoutOption WidthL = GUILayout.MaxWidth(115);
    private readonly GUILayoutOption WidthS = GUILayout.MaxWidth(80);
    private readonly GUILayoutOption WidthXS = GUILayout.MaxWidth(20);

    private EffectsSet MyTarget => target as EffectsSet;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Space();

        DrawTriggersOperations();

        DrawCurrentState();
    }

    private void DrawTriggersOperations()
    {
        GUILayout.Label("Triggers Effects", EditorStyles.boldLabel);
        Bh();
        GUILayout.Label("Selected Trigger: ", WidthL);
        ChosenTrigger = (EffectTriggerType) EditorGUILayout.EnumPopup(ChosenTrigger, WidthS);
        Eh();

        Bh();
        GUILayout.Label("Operations:");
        if (GUILayout.Button("Add Trigger", WidthL))
            AddTrigger();
        if (GUILayout.Button("Remove Trigger", WidthL))
            RemoveTrigger();
        Eh();
    }

    private void DrawCurrentState()
    {
        var allEffects = MyTarget.EffectsByTrigger;

        Space();


        if (allEffects != null)
        {
            Bv();

            foreach (var trigger in allEffects.Keys)
            {
                Bh();
                Bv();

                DrawLabelAndAddTrigger(allEffects, trigger);

                DrawDataEffects(allEffects, trigger);

                Ev();
                Eh();
            }

            Ev();
        }

        RemoveEmptyLists();
    }


    private void Space()
    {
        GUILayout.Space(25);
    }

    private void DrawLabelAndAddTrigger(EffectsByTrigger effectsByRole, EffectTriggerType trigger)
    {
        Bh();

        GUILayout.Label(trigger.ToString());
        if (GUILayout.Button("+", WidthXS))
            effectsByRole[trigger].Effects.Add(null);

        Eh();
    }

    private void DrawDataEffects(EffectsByTrigger effectsByRole, EffectTriggerType trigger)
    {
        for (var i = 0; i < effectsByRole[trigger].Effects.Count; i++)
        {
            Bh();
            effectsByRole[trigger].Effects[i] =
                (BaseEffectData) EditorGUILayout.ObjectField(effectsByRole[trigger].Effects[i], typeof(BaseEffectData),
                    true);
            if (GUILayout.Button("-", WidthXS))
            {
                var effect = effectsByRole[trigger].Effects[i];
                effectsByRole[trigger].Effects.Remove(effect);
            }

            Eh();
        }
    }

    private void RemoveEmptyLists()
    {
        var allEffects = MyTarget.EffectsByTrigger;
        var toRemove = allEffects.Where(x => x.Value.Effects.Count == 0)
            .Select(x => x.Key)
            .ToList();

        foreach (var key in toRemove)
            allEffects.Remove(key);
    }

    private void AddTrigger()
    {
        var allEffects = MyTarget.EffectsByTrigger;

        if (!allEffects.ContainsKey(ChosenTrigger))
        {
            var listEffect = new ListEffects();
            listEffect.Effects.Add(null);
            allEffects.Add(ChosenTrigger, listEffect);
        }
    }

    private void RemoveTrigger()
    {
        var allEffects = MyTarget.EffectsByTrigger;
        if (allEffects.ContainsKey(ChosenTrigger))
            allEffects.Remove(ChosenTrigger);
    }

    private void Bh()
    {
        EditorGUILayout.BeginHorizontal();
    }

    private void Eh()
    {
        EditorGUILayout.EndHorizontal();
    }

    private void Bv()
    {
        EditorGUILayout.BeginVertical();
    }

    private void Ev()
    {
        EditorGUILayout.EndVertical();
    }

    private void Label()
    {
    }
}