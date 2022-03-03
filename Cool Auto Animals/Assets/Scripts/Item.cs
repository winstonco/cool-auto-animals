using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour 
{
    private int _cost;
    private string _itemType;

    /// <summary>
    /// The item's cost.
    /// </summary>
    public int Cost
    {
        get => _cost;
    }

    /// <summary>
    /// The type of item.
    /// </summary>
    public string ItemType
    {
        get => _itemType;
    }

    /// <summary>
    /// Default constructor. Creates a new Apple Item that costs 3.
    /// </summary>
    public Item()
    {
        _itemType = "Apple";
        _cost = 3;
    }

    /// <summary>
    /// Creates a new Item.
    /// </summary>
    /// <param name="type">The item's type</param>
    /// <param name="cost">The item's cost</param>
    public Item(string type, int cost)
    {
        _itemType = type;
        _cost = cost;
    }

}
