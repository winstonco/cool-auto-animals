using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet
{
    private int _attack;
    private int _health;
    private string _petType;

    /// <summary>
    /// The pet's health.
    /// </summary>
    public int Health
    {
        get => _health;
        set => _health = value;
    }

    /// <summary>
    /// The pet's attack.
    /// </summary>
    public int Attack
    {
        get { return _attack; }
        set
        {
            if (value > 0)
            {
                _attack = value;
            } else
            {
                Debug.LogError($"ArgumentOutOfRangeException: Cannot set attack to a negative value. Given: {value}.");
                throw new System.ArgumentOutOfRangeException($"Cannot set attack to a negative value. Given: {value}.");
            }
        }
    }

    /// <summary>
    /// The type of pet.
    /// </summary>
    public string PetType
    {
        get => _petType;
        set => _petType = value;
    }

    /// <summary>
    /// Default constructor. Creates a new 1/1 Sloth Pet.
    /// </summary>
    protected Pet()
    {
        _health = 1;
        _attack = 1;
        _petType = "Sloth";
    }

    /// <summary>
    /// Creates a new Pet.
    /// </summary>
    /// <param name="health">The pet's health</param>
    /// <param name="attack">The pet's attack</param>
    protected Pet(int health, int attack, string type)
    {
        _health = health;
        _attack = attack;
        _petType = type;
    }
}
