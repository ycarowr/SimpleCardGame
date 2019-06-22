using System;
using System.Collections.Generic;
using Patterns;

/// <summary>
///     TODO: Not fully implemented. Demands to load the [tag, text] from a file.
/// </summary>
public class Localization : Singleton<Localization>
{
    private readonly Dictionary<LocalizationIds, string> data = new Dictionary<LocalizationIds, string>();

    public Localization()
    {
        foreach (var id in Enum.GetValues(typeof(LocalizationIds))) data.Add((LocalizationIds) id, id.ToString());
    }

    public string Get(LocalizationIds id)
    {
        return data[id];
    }
}