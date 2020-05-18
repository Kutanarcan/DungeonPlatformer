using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    public static void HandleKeyDown(this KeyCode keyCode, System.Action action)
    {
        if (Input.GetKeyDown(keyCode))
        {
            action?.Invoke();
        }
    }


    public static List<K> SaveDictionary<T, K>(this Dictionary<T, K> dictionary)
    {
        List<K> tmplist = new List<K>();

        foreach (var skill in dictionary)
        {
            tmplist.Add(skill.Value);
        }

        return tmplist;
    }
}

