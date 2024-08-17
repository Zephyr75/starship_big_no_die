using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SerializablePair<TKey, TValue>
{
    [SerializeField]
    public TKey key;

    [SerializeField]
    public TValue value;

    

    
}
[Serializable]
public class SerializableDictionary<TKey, TValue>
{
    [SerializeField] private List<SerializablePair<TKey, TValue>> listItem;
    public Dictionary<TKey, TValue> ToDictionary()
    {
        Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>();

        for (int i = 0; i < listItem.Count; i++)
        {
            dictionary[listItem[i].key] = listItem[i].value;
        }

        return dictionary;
    }
}