using System;
using System.Collections.Generic;
using UnityEngine;

public enum Condition
{
    START,
    PAUSE,
    EXIT
}


public static class EventManager
{
    private static Dictionary<Condition, Action> dictionary = new();

    public static void Subscribe(Condition condition, Action action)
    {
        if (dictionary.ContainsKey(condition))
        {
            dictionary[condition] += action;
        }
        else
        {
            dictionary[condition] = action;
        }
    }

    public static void UnSubscribe(Condition condition, Action action)
    {
        if (dictionary.ContainsKey(condition))
        {
            dictionary[condition] -= action;
        }
    }

    public static void Publish(Condition condition)
    {
        if (dictionary.TryGetValue(condition, out Action action))
        {
            action?.Invoke();
        }
    }

}
