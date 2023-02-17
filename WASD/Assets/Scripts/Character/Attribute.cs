using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Attribute
{
    private Sprite icon;
    private string name;
    private string description;
    private int baseValue;

    private List<int> modifiers = new List<int>();

    public Attribute(int value, string iconName, string name, string description)
    {
        if(!(iconName == ""))
        {
            icon = Resources.Load<Sprite>(iconName);
        }
        this.name = name;
        this.description = description;
        baseValue = value;
    }

    public Sprite Icon { get { return icon; }}

    public string Name { get { return name; }}

    public string Description { get { return description; }}

    public int GetValue()
    {
        int finalValue = baseValue;
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
}
