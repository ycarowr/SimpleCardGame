using System.Linq;
using SimpleCardGames.Data.Effects;
using UnityEditor;
using UnityEngine;
using static SimpleCardGames.Data.Effects.EffectsSet;

[CustomEditor(typeof(EffectsSet))]
public class EffectsSetEditor : Editor
{
    //cell sizes
    readonly GUILayoutOption WidthL = GUILayout.MaxWidth(115);
    readonly GUILayoutOption WidthS = GUILayout.MaxWidth(80);
    readonly GUILayoutOption WidthXS = GUILayout.MaxWidth(20);
    EffectTriggerType ChosenTrigger = EffectTriggerType.OnPlay;

    EffectsSet MyTarget => target as EffectsSet;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Space();

        DrawTriggersOperations();

        DrawCurrentState();

        if (GUILayout.Button("Force Save"))
            SaveChanges();
    }

    void DrawTriggersOperations()
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

    void DrawCurrentState()
    {
        var allEffects = MyTarget.Register;

        Space();


        if (allEffects != null)
        {
            Bv();

            foreach (var trigger in allEffects.Keys)
            {
                Bh();
                Bv();

                DrawLabelAndAddTrigger(allEffects, trigger.tType);

                DrawDataEffects(allEffects, trigger.tType);

                Ev();
                Eh();
            }

            Ev();
        }

        RemoveEmptyLists();
    }


    void Space() => GUILayout.Space(25);

    void DrawLabelAndAddTrigger(EffectRegister effectsByRole, EffectTriggerType trigger)
    {
        var effcond = effectsByRole.First(eff => eff.Key.tType == trigger).Key;
        Bh();

        GUILayout.Label(trigger.ToString());
        if (GUILayout.Button("+", WidthXS))
        {
            effectsByRole[effcond].Effects.Add(null);
            SaveChanges();
        }

        Eh();
    }

    void DrawDataEffects(EffectRegister effectsByRole, EffectTriggerType trigger)
    {
        var effcond = effectsByRole.First(eff => eff.Key.tType == trigger).Key;
        for (var i = 0; i < effectsByRole[effcond].Effects.Count; i++)
        {
            Bh();
            var cached = effectsByRole[effcond].Effects[i];
            effectsByRole[effcond].Effects[i] =
                (BaseEffectData) EditorGUILayout.ObjectField(effectsByRole[effcond].Effects[i], typeof(BaseEffectData),
                    true);

            if (cached != effectsByRole[effcond].Effects[i])
                SaveChanges();

            if (GUILayout.Button("-", WidthXS))
            {
                var effect = effectsByRole[effcond].Effects[i];
                effectsByRole[effcond].Effects.Remove(effect);
                SaveChanges();
            }

            Eh();
        }
    }

    void RemoveEmptyLists()
    {
        var allEffects = MyTarget.Register;
        var toRemove = allEffects.Where(x => x.Value.Effects.Count == 0)
            .Select(x => x.Key)
            .ToList();

        foreach (var key in toRemove)
            allEffects.Remove(key);
    }

    void AddTrigger()
    {
        var allEffects = MyTarget.Register;

        if (!allEffects.Any(eff => eff.Key.tType == ChosenTrigger))
        {
            var listEffect = new ListEffects();
            listEffect.Effects.Add(null);
            allEffects.Add(new EffectTriggerCondition(ChosenTrigger, 1), listEffect);
        }

        SaveChanges();
    }

    void RemoveTrigger()
    {
        var allEffects = MyTarget.Register;
        if (allEffects.Any(eff => eff.Key.tType == ChosenTrigger))
            allEffects.Remove(allEffects.First(eff => eff.Key.tType == ChosenTrigger).Key);
        SaveChanges();
    }

    void Bh() => EditorGUILayout.BeginHorizontal();

    void Eh() => EditorGUILayout.EndHorizontal();

    void Bv() => EditorGUILayout.BeginVertical();

    void Ev() => EditorGUILayout.EndVertical();

    void Label()
    {
    }

    void SaveChanges()
    {
        EditorUtility.SetDirty(target);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
}