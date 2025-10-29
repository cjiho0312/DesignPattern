using System.Collections.Generic;
using UnityEngine;

public class CoroutineManager
{
    static Dictionary<float, WaitForSeconds> dictionary = new();

    public static WaitForSeconds WaitForSecond(float time)
    {
        if (!dictionary.ContainsKey(time))
        {
            dictionary.Add(time, new WaitForSeconds(time));
        }

        return dictionary[time];
    }
}

