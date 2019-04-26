using UnityEditor;
using UnityEngine;
using System.Linq;
using SimpleCardGame.Data.Effects;

[CustomEditor(typeof(EffectsSet))]
public class CardDataEffectsEditor : Editor
{
    EffectTriggerType ChosenTrigger = EffectTriggerType.OnPlay;

    EffectsSet MyTarget { get { return target as EffectsSet; } }

    //cell sizes
    GUILayoutOption WidthL = GUILayout.MaxWidth(115);
    GUILayoutOption WidthS = GUILayout.MaxWidth(80);
    GUILayoutOption WidthXS = GUILayout.MaxWidth(20);

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Space();

        DrawTriggersOperations();

        DrawCurrentState();
    }

    void DrawTriggersOperations()
    {
        GUILayout.Label("Triggers Effects", EditorStyles.boldLabel);
        Bh();
        GUILayout.Label("Selected Trigger: ", WidthL);
        ChosenTrigger = (EffectTriggerType)EditorGUILayout.EnumPopup(ChosenTrigger, WidthS);
        Eh();

        Bh();
        GUILayout.Label("Operations:");
        if (GUILayout.Button("Add Trigger", WidthL))
            AddTrigger();
        if (GUILayout.Button("Remove Trigger", WidthL))
            RemoveTrigger();
        Eh();
    }

    void DrawCurrentState()
    {
        var allEffects = MyTarget.EffectsByTrigger;

        Space();


        if (allEffects != null)
        {
            Bv();
            
            foreach (EffectTriggerType trigger in allEffects.Keys)
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


    void Space()
    {
        GUILayout.Space(25);
    }

    void DrawLabelAndAddTrigger(EffectsByTrigger effectsByRole, EffectTriggerType trigger)
    {
        Bh();

        GUILayout.Label(trigger.ToString());
        if (GUILayout.Button("+", WidthXS))
            effectsByRole[trigger].Effects.Add(null);

        Eh();
    }

    void DrawDataEffects(EffectsByTrigger effectsByRole, EffectTriggerType trigger)
    {
        for (int i = 0; i < effectsByRole[trigger].Effects.Count; i++)
        {
            Bh();
            effectsByRole[trigger].Effects[i] = (BaseEffectData)EditorGUILayout.ObjectField(effectsByRole[trigger].Effects[i], typeof(BaseEffectData), true);
            if (GUILayout.Button("-", WidthXS))
            {
                var effect = effectsByRole[trigger].Effects[i];
                effectsByRole[trigger].Effects.Remove(effect);
            }

            Eh();
        }
    }

    void RemoveEmptyLists()
    {
        var allEffects = MyTarget.EffectsByTrigger;
        var toRemove = allEffects.Where(x => x.Value.Effects.Count == 0)
                .Select(x => x.Key)
                .ToList();

        foreach (var key in toRemove)
            allEffects.Remove(key);
    }
    
    void AddTrigger()
    {
        var allEffects = MyTarget.EffectsByTrigger;
        
        if (!allEffects.ContainsKey(ChosenTrigger))
        {
            var listEffect = new ListEffects();
            listEffect.Effects.Add(null);
            allEffects.Add(ChosenTrigger, listEffect);
        }
    }

    void RemoveTrigger()
    {
        var allEffects = MyTarget.EffectsByTrigger;
        if (allEffects.ContainsKey(ChosenTrigger))
            allEffects.Remove(ChosenTrigger);
    }

    void Bh()
    {
        EditorGUILayout.BeginHorizontal();
    }

    void Eh()
    {
        EditorGUILayout.EndHorizontal();
    }

    void Bv()
    {
        EditorGUILayout.BeginVertical();
    }

    void Ev()
    {
        EditorGUILayout.EndVertical();
    }

    void Label()
    {

    }
}
