using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SerializableSortedDictionary<TKey, TValue> : SortedDictionary<TKey, TValue>, ISerializationCallbackReceiver
{
    [SerializeField]
    protected List<TKey> MyKeys = new List<TKey>();

    [SerializeField]
    protected List<TValue> MyValues = new List<TValue>();

    // save the dictionary to lists
    public void OnBeforeSerialize()
    {
        MyKeys.Clear();
        MyValues.Clear();
        foreach (KeyValuePair<TKey, TValue> pair in this)
        {
            MyKeys.Add(pair.Key);
            MyValues.Add(pair.Value);
        }
    }

    // load dictionary from lists
    public void OnAfterDeserialize()
    {
        this.Clear();

        if (MyKeys.Count != MyValues.Count)
            throw new System.Exception(string.Format("there are keys and values after deserialization. Make sure that both key and value types are serializable."));

        for (int i = 0; i < MyKeys.Count; i++)
            this.Add(MyKeys[i], MyValues[i]);
    }
}

[Serializable]
public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
{ 
    [SerializeField]
    protected List<TKey> MyKeys = new List<TKey>();

    [SerializeField]
    protected List<TValue> MyValues = new List<TValue>();

    // save the dictionary to lists
    public void OnBeforeSerialize()
    {
        MyKeys.Clear();
        MyValues.Clear();
        foreach (KeyValuePair<TKey, TValue> pair in this)
        {
            MyKeys.Add(pair.Key);
            MyValues.Add(pair.Value);
        }
    }

    // load dictionary from lists
    public void OnAfterDeserialize()
    {
        this.Clear();

        if (MyKeys.Count != MyValues.Count)
            throw new System.Exception(string.Format("there are keys and values after deserialization. Make sure that both key and value types are serializable."));

        for (int i = 0; i < MyKeys.Count; i++)
            this.Add(MyKeys[i], MyValues[i]);
    }
}