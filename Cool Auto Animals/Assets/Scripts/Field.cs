using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour, IBench, IShop
{
    private static int s_maxSize = 5;
    private FieldPet[] _myPets = new FieldPet[s_maxSize];
    private int size;

    /// <summary>
    /// Returns the array of pets on your team.
    /// </summary>
    public FieldPet[] MyPets
    {
        get => _myPets;
    }

    private void Start()
    {
        for (int i = 0; i < s_maxSize - 1; i++)
        {
            _myPets[i] = null;
        }
        size = 0;
    }

    public void AddPet(FieldPet pet)
    {
        AddPet(pet, size);
        size++;
    }

    public void AddPet(FieldPet pet, int index)
    {
        // Check that the pet is not null
        if (pet == null)
        {
            Debug.LogError($"ArgumentNullException: Expected a FieldPet pet, but received null.");
            throw new System.ArgumentNullException($"Expected a FieldPet pet, but received null.");
        }
        // Check that the team is not full
        if (size == s_maxSize)
        {
            Debug.LogError($"InvalidOperationException: The team is already at max capacity.");
            throw new System.InvalidOperationException($"The team is already at max capacity.");
        }
        // Check index to be between 0 and max size
        if (index < 0 || index > s_maxSize)
        {
            Debug.LogError($"ArgumentOutOfRangeException: Index must be between 0 and {s_maxSize}, inclusive. Given: {index}.");
            throw new System.ArgumentOutOfRangeException($"Index must be between 0 and {s_maxSize}, inclusive. Given: {index}.");
        }
        // If there is a pet already at that spot, move it left (decrease index), then right if no available spots
        if (_myPets[index] != null)
        {
            // If moving was unsuccessful
            if (MovePet(index) == false)
            {
                return;
            }
        }
        // Check again that the space is open
        if (_myPets[index] != null)
        {
            Debug.LogError($"InvalidOperationException: Was unable to add in new pet '{pet}' at index {index}.");
            throw new System.InvalidOperationException($"Was unable to add in new pet '{pet}' at index {index}.");
        }
        // Add in new pet and increment size
        _myPets[index] = pet;
        size++;
    }

    public FieldPet SellPet(int index)
    {
        // Check that the space on the bench is not empty
        // If it is, throw an exception
        // Save the sold pet
        // Remove pet from array
        // Trigger sell event
        // Increase gold by pet's level
        // Return saved pet
        return null;
    }

    public bool MovePet(int start)
    {
        // First check if can move left
        // From start, check positions to the left to find the first empty space
        for (int i = start - 1; i > 0; i--)
        {
            // An empty space at index i was found
            if (_myPets[i] == null)
            {
                // Loop back to move the pets
                for (int j = i; j < start; j++)
                {
                    _myPets[j] = _myPets[j + 1];
                }
                // Spot at start pos is now empty
                _myPets[start] = null;
                return true;
            }
        }
        // No empty space found to the left
        // From start, check for spaces on the right
        for (int i = start + 1; i < s_maxSize - 1; i++)
        {
            // An empty space at index i was found
            if (_myPets[i] == null)
            {
                // Loop back to move the pets
                for (int j = i; j > start; j--)
                {
                    _myPets[j] = _myPets[j - 1];
                }
                // Spot at start pos is now empty
                _myPets[start] = null;
                return true;
            }
        }

        // If no empty spaces found, return false
        return false;
    }

    public Pet BuyPet(int i)
    {
        throw new System.NotImplementedException();
    }

    public Item BuyItem()
    {
        throw new System.NotImplementedException();
    }

    public void Refresh()
    {
        throw new System.NotImplementedException();
    }

    public void FreezePet(int i)
    {
        throw new System.NotImplementedException();
    }

    public void FreezeItem(int i)
    {
        throw new System.NotImplementedException();
    }
}
