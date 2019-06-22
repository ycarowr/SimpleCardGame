using System.Linq;
using SimpleCardGames.Data.Effects;
using UnityEditor;
using UnityEngine;
using static SimpleCardGames.Data.Effects.EffectsSet;

[CustomEditor(typeof(EffectsSet))]
public class EffectsSetEditor : Editor
{
    //cell sizes
    private readonly GUILayoutOption WidthL = GUILayout.MaxWidth(115);
    private readonly GUILayoutOption WidthS = GUILayout.MaxWidth(80);
    private readonly GUILayoutOption WidthXS = GUILayout.MaxWidth(20);
    private EffectTriggerType ChosenTrigger = EffectTriggerType.OnPlay;

    private EffectsSet MyTarget => target as EffectsSet;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Space();

        DrawTriggersOperations();

        DrawCurrentState();

        if (GUILayout.Button("Force Save"))
            SaveChanges();
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


    private void Space()
    {
        GUILayout.Space(25);
    }

    private void DrawLabelAndAddTrigger(EffectRegister effectsByRole, EffectTriggerType trigger)
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

    private void DrawDataEffects(EffectRegister effectsByRole, EffectTriggerType trigger)
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

    private void RemoveEmptyLists()
    {
        var allEffects = MyTarget.Register;
        var toRemove = allEffects.Where(x => x.Value.Effects.Count == 0)
            .Select(x => x.Key)
            .ToList();

        foreach (var key in toRemove)
            allEffects.Remove(key);
    }

    private void AddTrigger()
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

    private void RemoveTrigger()
    {
        var allEffects = MyTarget.Register;
        if (allEffects.Any(eff => eff.Key.tType == ChosenTrigger))
            allEffects.Remove(allEffects.First(eff => eff.Key.tType == ChosenTrigger).Key);
        SaveChanges();
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

    private void SaveChanges()
    {
        EditorUtility.SetDirty(target);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
}