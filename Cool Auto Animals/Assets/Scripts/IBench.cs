using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBench
{
    /// <summary>
    /// Sells the pet at the given index.
    /// </summary>
    /// <param name="index">The index</param>
    /// <returns>The pet that was sold</returns>
    FieldPet SellPet(int i);

    /// <summary>
    /// Adds a pet to the front of the team.
    /// </summary>
    /// <param name="pet">The pet to add</param>
    void AddPet(FieldPet pet);

    /// <summary>
    /// Adds a pet at the given index.
    /// </summary>
    /// <param name="pet">The pet to add</param>
    /// <param name="index">The index</param>
    void AddPet(FieldPet pet, int i);
}
