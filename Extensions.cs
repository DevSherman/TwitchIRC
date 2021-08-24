using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extensions
{
    public static string GetValuesContain(string original, string exclude)
    {
        int from = original.IndexOf(exclude) + exclude.Length;
        string value = "";

        for (int i = from; i < original.Length; i++)
        {
            if (original[i] == ' ') return value;
            value += original[i];
        }
        return value;
    }
    public static string GetValuesBetween(string original, string first, string final)
    {
        int from = original.IndexOf(first) + first.Length;
        int to = original.LastIndexOf(final);

        return original.Substring(from, to - from);
    }
    public static string SplitToEnd(string original, string exclude)
    {
        int from = original.IndexOf(exclude) + exclude.Length;
        string value = "";

        for (int i = from; i < original.Length; i++)
        {
            value += original[i];
        }
        return value;
    }
}
