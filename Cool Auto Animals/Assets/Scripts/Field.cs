using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour, IBench, IShop
{
    // Variable purely for if something was dropped in the child slots
    private bool droppedInSlot = false;

    private static int s_maxTeamSize = 5;
    private static int s_maxShopSizePets;
    private static int s_maxShopSizeFood;
    public static int s_turnNum;
    public static int s_wins;

    private FieldPet[] _myPets = new FieldPet[s_maxTeamSize];
    public int size;

    /// <summary>
    /// Returns the array of pets on your team.
    /// </summary>
    public FieldPet[] MyPets
    {
        get => _myPets;
    }

    public bool DroppedInSlot
    {
        get => droppedInSlot;
        set => droppedInSlot = value;
    }

    private void Start()
    {
        s_maxShopSizePets = 3;
        s_maxShopSizeFood = 1;

        for (int i = 0; i < s_maxTeamSize - 1; i++)
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
        if (size == s_maxTeamSize)
        {
            Debug.LogError($"InvalidOperationException: The team is already at max capacity.");
            throw new System.InvalidOperationException($"The team is already at max capacity.");
        }
        // Check index to be between 0 and max size
        if (index < 0 || index > s_maxTeamSize)
        {
            Debug.LogError($"ArgumentOutOfRangeException: Index must be between 0 and {s_maxTeamSize}, inclusive. Given: {index}.");
            throw new System.ArgumentOutOfRangeException($"Index must be between 0 and {s_maxTeamSize}, inclusive. Given: {index}.");
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
        for (int i = start + 1; i < s_maxTeamSize - 1; i++)
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
