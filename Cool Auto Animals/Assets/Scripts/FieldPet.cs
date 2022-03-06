using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public abstract class FieldPet : Pet
{
    private int _position;
    private int _level;
    private Item _heldItem;
    private bool _isAlive;

    /// <summary>
    /// The pet's position. Must be a value between 0 and 4, inclusive.
    /// </summary>
    public int Position
    {
        get => _position;
        set
        {
            if (value >= 0 && value <= 4)
            {
                _position = value;
            }
            else
            {
                Debug.LogError($"ArgumentOutOfRangeException: Position must be between 0 and 4, inclusive. Given: {value}.");
                throw new System.ArgumentOutOfRangeException($"Position must be between 0 and 4, inclusive. Given: {value}.");
            }
        }
    }

    /// <summary>
    /// Returns true if this pet is alive.
    /// </summary>
    public bool IsAlive
    {
        get => _isAlive;
    }

    /// <summary>
    /// The pet's held item.
    /// </summary>
    public Item HeldItem
    {
        get => _heldItem;
        set => GiveItem(value);
    }

    /// <summary>
    /// This pet's level.
    /// </summary>
    public int Level
    {
        get => _level;
        set => _level = value;
    }

    /// <summary>
    /// Default constructor. Creates a new 1/1 Sloth FieldPet.
    /// </summary>
    protected FieldPet() : base()
    {
        _isAlive = true;
        _level = 1;
        _heldItem = null;
    }
    
    /// <summary>
    /// Creates a new FieldPet.
    /// </summary>
    /// <param name="attack">The pet's attack</param>
    /// <param name="health">The pet's health</param>
    protected FieldPet(int attack, int health, string type) : base(attack, health, type)
    {
        _isAlive = true;
        _level = 1;
        _heldItem = null;
    }

    /// <summary>
    /// Uses the pet's ability. This does nothing by default.
    /// </summary>
    public abstract void UseAbility();

    /// <summary>
    /// Deals damage equal to this pet's attack to the target pet.
    /// </summary>
    /// <param name="target">The target pet</param>
    public void AttackPet(FieldPet target)
    {
        target.ReceiveDamage(this.Attack);
    }

    /// <summary>
    /// This pet takes a given amount of damage. If holding 'Garlic Armor', the damage is reduced by 2, minimum 1 damage taken. If<br></br>
    /// holding 'Melon Armor', the damage is reduced by 20, minimum 0 damage taken, and the item is destroyed until end of combat.
    /// </summary>
    /// <param name="damage">the amount of damage received</param>
    /// <returns>The amount of health remaining</returns>
    public int ReceiveDamage(int damage)
    {
        int takeDmg = damage;
        if (_heldItem.ItemType.Equals("Garlic Armor"))
        {
            takeDmg -= 2;
            if (takeDmg < 1)
            {
                takeDmg = 1;
            }
        }
        else if (_heldItem.ItemType.Equals("Melon Armor"))
        {
            if (takeDmg >= 20)
            {
                takeDmg -= 20;
            } else
            {
                takeDmg = 0;
            }
        }
        this.Health -= takeDmg;
        return this.Health;
    }

    /// <summary>
    /// This pet is given an item.
    /// </summary>
    /// <returns>
    /// The last item it was holding, or null if it was previously not holding an item
    /// </returns>
    public Item GiveItem(Item item)
    {
        Item prevHeld = _heldItem;
        _heldItem = item;
        if (prevHeld == null) { return null; }
        else { return prevHeld; }
    }
}
