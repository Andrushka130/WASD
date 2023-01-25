using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

[System.Serializable]
public class Attribute
{
    [SerializeField]
    private float baseValue;
    private Sprite icon;

    private List<int> modifiers = new List<int>();

    public Attribute(float value, string iconName)
    {
        baseValue = value;
        icon = Resources.Load<Sprite>(iconName);
    }

    public float GetValue()
    {
        float finalValue = baseValue;
        modifiers.ForEach(x => finalValue += x);
        return finalValue;
    }

    public void AddModifier (int modifier)
    {
        if(modifier != 0)
            modifiers.Add(modifier);
    }

    public void RemoveModifier (int modifier)
    {
        if (modifier != 0)
            modifiers.Remove(modifier);
    }

    public void ChangeAttribute(int ammount)
    {
        baseValue += ammount;
    }

    public Sprite Icon
    {
        get { return icon; }
    }
    
}